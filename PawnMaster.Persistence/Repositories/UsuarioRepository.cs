using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PawnMaster.Persistence.Data;
using PawnMaster.Persistence.Dtos;
using PawnMaster.Persistence.Repositories.InterfaceRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace PawnMaster.Persistence.Repositories
{
    public class UsuarioRepository : InterfazUsuarioRepository
    {
        private readonly ApplicationDbContext _bd;
        private string claveSecreta;
        public UsuarioRepository(ApplicationDbContext _bd, IConfiguration config)
        {
            this._bd = _bd;
            claveSecreta = config["JwtSettings:Key"];   
        }

        public bool EsCorreoUnico(string correo)
        {
            var correoUsuario = _bd.Usuarios.FirstOrDefault( u => u.Correo == correo );
            if ( correoUsuario == null )
            {
                return true;
            }
            else { return false; }
        }

        public Usuario GetJugador(int jugadorId)
        {
            return _bd.Usuarios.FirstOrDefault(u => u.Id == jugadorId); ;
        }

        public ICollection<Usuario> GetJugadores()
        {
            return _bd.Usuarios.OrderBy(u => u.Nombre).ToList(); ;
        }

        public bool Registro(UsuarioRegistroDto usuarioRegistroDto)
        {
            var passwordHasher = new PasswordHasher<string>();
            var hashedPassword = passwordHasher.HashPassword(null, usuarioRegistroDto.Password);

            var jugador = new Usuario() 
            {
                Correo = usuarioRegistroDto.CorreoElectronico,
                Nombre = usuarioRegistroDto.Nombre,
                Password = hashedPassword,
                Role = "Usuario",
            };

            _bd.Usuarios.Add(jugador);

            _bd.SaveChanges();

            return true;
        }

        public UsuarioLoginRespuestaDto Login(UsuarioLoginDto usuarioLoginDto)

        {
            var usuario = _bd.Usuarios.FirstOrDefault(
                u => u.Correo.ToLower() == usuarioLoginDto.CorreoElectronico.ToLower()
               
                );

            if (usuario == null )
            {
                var usuarioRespuesta = new UsuarioLoginRespuestaDto()
                {
                    Token = ""
                    
                };
                return usuarioRespuesta;
            }

            var passwordHasher = new PasswordHasher<string>();

            // Comprueba si la contraseña proporcionada coincide con el hash almacenado.
            var result = passwordHasher.VerifyHashedPassword(null, usuario.Password, usuarioLoginDto.Password);

            if (result != Microsoft.AspNetCore.Identity.PasswordVerificationResult.Success)
            {
                var usuarioRespuesta = new UsuarioLoginRespuestaDto()
                {
                    Token = ""

                };
                return usuarioRespuesta;
            }

            //Aqui existe el usuario
            var roles = usuario.Role;

            var manejadorToken = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(claveSecreta);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Correo),
                    new Claim(ClaimTypes.Role, roles)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = manejadorToken.CreateToken(tokenDescriptor);
            var usuarioLoginRespuestaDto = new UsuarioLoginRespuestaDto()
            {
                Token = manejadorToken.WriteToken(token),
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                UserName = usuario.Correo
            };
            return usuarioLoginRespuestaDto;
        }

    }
}
