using PawnMaster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Persistence.Repositories.InterfaceRepository
{
    internal interface InterfazPartidaRepository
    {
        bool GuardarEstadoPartida(Partida partida);
        Partida RecuperarEstadoPartida (int id);    
    }
}
