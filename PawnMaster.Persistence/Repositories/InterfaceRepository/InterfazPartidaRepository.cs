using PawnMaster.Model;
using PawnMaster.Persistence.Dtos;

namespace PawnMaster.Persistence.Repositories.InterfaceRepository
{
    public interface InterfazPartidaRepository
    {
        public void GuardarEstadoPartidaDespuesDeUnMovimiento(Casilla Origen, Casilla Destino, int partidaId);
        public int CrearPartida(PartidaDataDto Partida);
        public PartidaRecuperadaDto RecuperarEstadoPartida(int id);
        //public List<Data.Ficha> RecuperarEstadoPartida(int id);
    }
}
