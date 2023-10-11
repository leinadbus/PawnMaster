using PawnMaster.Model;
using PawnMaster.Persistence.Dtos;

namespace PawnMaster.Persistence.Dtos
{
    public class PartidaDataDto
    {
        
        public DateTime Date { get; set; }
        public int JugadorBlancoId { get; set; }
        public int JugadorNegroId { get; set; }
        public List<FichaDto> ListaDeFichas { get; set; }
        public char JugadorActual { get; set; }
        public bool EnJuego { get; set; }
        public int Id { get; set; }
    }
}
