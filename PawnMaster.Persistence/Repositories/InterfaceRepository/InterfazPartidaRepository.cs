using PawnMaster.Model;
using PawnMaster.Persistence.Dtos;

namespace PawnMaster.Persistence.Repositories.InterfaceRepository
{
    public interface InterfazPartidaRepository
    {
        public void GuardarEstadoPartidaDespuesDeUnMovimiento(Casilla Origen, Casilla Destino, int partidaId);
        public int CrearPartida(PartidaDto Partida, int IdBlanco, int IdNegro);
        public PartidaRecuperadaDto RecuperarEstadoPartida(int id);

    }
}
