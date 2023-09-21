using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Configuration;
using NHibernate.Mapping.ByCode.Impl;
using PawnMaster.Model;
using PawnMaster.Persistence.Data;
using PawnMaster.Persistence.Dtos;
using PawnMaster.Persistence.Repositories.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Persistence.Repositories
{
    public class UsuarioRepository : InterfazUsuarioRepository
    {
        private readonly ApplicationDbContext _bd;
        //private readonly UserManager<Usuario> _userManager;
        public UsuarioRepository(ApplicationDbContext _bd)
        {
            this._bd = _bd;
        }

        public bool EsCorreoUnico(string correo)
        {
            var correoUsuario = _bd.Jugadores.FirstOrDefault( u => u.Correo == correo );
            if ( correoUsuario == null )
            {
                return true;
            }
            else { return false; }
        }

        public Usuario GetJugador(int jugadorId)
        {
            return _bd.Jugadores.FirstOrDefault(u => u.Id == jugadorId);
        }

        public ICollection<Usuario> GetJugadores()
        {
            return _bd.Jugadores.OrderBy(u => u.Nombre).ToList(); ;
        }

        public bool Registro(UsuarioRegistroDto usuarioRegistroDto)
        {
            var jugador = new Usuario() 
            {
                Correo = usuarioRegistroDto.CorreoElectronico,
                Nombre = usuarioRegistroDto.Nombre,
                Password = usuarioRegistroDto.Password,
                Role = "Usuario",
            };

            _bd.Jugadores.Add(jugador);

            _bd.SaveChanges();

            return true;
        }
    }
}
