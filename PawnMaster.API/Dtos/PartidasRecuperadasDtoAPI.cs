using PawnMaster.Model;

namespace PawnMaster.API.Dtos
{
    public class PartidasRecuperadasDtoAPI
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int JugadorBlanco { get; set; }
        public int JugadorNegro { get; set; }
        public char JugadorActual { get; set; }
        public bool EnJuego { get; set; }
    }
}
