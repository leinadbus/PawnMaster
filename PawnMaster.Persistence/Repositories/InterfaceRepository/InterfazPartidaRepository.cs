using PawnMaster.Model;
using PawnMaster.Persistence.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Persistence.Repositories.InterfaceRepository
{
    public interface InterfazPartidaRepository
    {
        public void GuardarEstadoPartidaDespuesDeUnMovimiento(Casilla Origen, Casilla Destino, int partidaId);
        public bool CrearPartida(PartidaDto Partida, int IdBlanco, int IdNegro);
        public PartidaRecuperadaDto RecuperarEstadoPartida(int id);

    }
}
