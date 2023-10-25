using PawnMaster.Persistence.Data;
using PawnMaster.Persistence.Dtos;

namespace PawnMaster.Persistence.Repositories.InterfaceRepository
{
    public interface InterfazUsuarioRepository
    {
        ICollection<Usuario> GetJugadores();
        Usuario GetJugador(int id);
        bool EsCorreoUnico(string correo);
        bool Registro(UsuarioRegistroDto registro);
        UsuarioLoginRespuestaDto Login(UsuarioLoginDto usuarioLoginDto);
    }
}
