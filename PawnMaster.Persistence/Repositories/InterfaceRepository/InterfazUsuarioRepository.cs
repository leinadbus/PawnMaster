using PawnMaster.Persistence.Data;
using PawnMaster.Persistence.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Persistence.Repositories.InterfaceRepository
{
    public interface InterfazUsuarioRepository
    {
        ICollection<Usuario> GetJugadores();
        Usuario GetJugador(int jugadorId);
        bool EsCorreoUnico(string correo);
        bool Registro(UsuarioRegistroDto usuarioRegistroDto);


    }
}
