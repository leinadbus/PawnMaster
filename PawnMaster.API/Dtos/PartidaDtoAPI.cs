using PawnMaster.Model;

namespace PawnMaster.API.Dtos
{
    public class PartidaDtoAPI
    {
        public Guid Identificador { get; set; }

        public DateTime Date { get; set; }

        private Tablero Tablero { get; set; }

        public Jugador JugadorBlanco { get; set; }
        public Jugador JugadorNegro { get; set; }

        public List<string> ListaDeMovimientos { get; set; }

        public Jugador JugadorActual { get; set; }
    }
}
