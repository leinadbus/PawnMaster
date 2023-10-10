using PawnMaster.Model;
using PawnMaster.Persistence.Dtos;

namespace PawnMaster.Persistence.Repositories.InterfaceRepository
{
    public interface InterfazPartidaRepository
    {
        public void GuardarEstadoPartidaDespuesDeUnMovimiento(Casilla Origen, Casilla Destino, int partidaId);
        public int CrearPartida(Data.Partida Partida, List<FichaDto> Listafichas);
        public PartidaRecuperadaDto RecuperarEstadoPartida(int id);

    }
}
