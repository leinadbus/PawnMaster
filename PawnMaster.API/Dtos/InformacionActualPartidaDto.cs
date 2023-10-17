namespace PawnMaster.API.Dtos
{
    public class InformacionActualPartidaDto
    {
        public char Turno {  get; set; }
        public DateTime Tiempo { get; set; }
        public List<FichasDtoApi> ListaFichasEnJuego { get; set; }
        public List<FichasDtoApi> ListaFichasFueraDeJuego { get; set; }

    }
}
