using PawnMaster.Model;

namespace PawnMaster.API.Dtos
{
    public class PartidaDtoAPI
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public Tablero Tablero { get; set; }

        public Jugador JugadorBlanco { get; set; }
        public Jugador JugadorNegro { get; set; }

        public List<string> ListaDeMovimientos { get; set; }

        public Jugador JugadorActual { get; set; }
    }
}
