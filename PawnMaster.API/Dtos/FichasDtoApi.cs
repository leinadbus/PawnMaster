namespace PawnMaster.API.Dtos
{
    public class FichasDtoApi
    {
        public int PosicionVertical { get; set; }
        public char PosicionHorizontal { get; set; }
        public char Simbolo { get; set; }
        public char LetracolorRepresentante { get; set; }
        public bool EnJuego { get; set; }
    }
}
