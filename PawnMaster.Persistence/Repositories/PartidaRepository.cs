using PawnMaster.Model;
using PawnMaster.Persistence.Dtos;
using PawnMaster.Persistence.Repositories.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Persistence.Repositories
{
    public class PartidaRepository : InterfazPartidaRepository
    {
        public Partida Partida { get; set; }
        public bool MantenerEstadoPartida(Partida partida)
        {
            Partida = partida;
            return true;
        }
        public bool GuardarEstadoPartida(Partida partida)
        {
            throw new NotImplementedException();
        }

        public Partida RecuperarEstadoPartida(int id)
        {
            throw new NotImplementedException();
        }
    }
}
