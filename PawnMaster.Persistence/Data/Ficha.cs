using PawnMaster.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Persistence.Data
{
    public class Ficha
    {
        public int Id { get; set; }
        public char CaracterFicha { get; set; }
        public int partidaId { get; set; }
        public Partida Partida { get; set; }
        //public ColorFicha Color { get; set; }
        public Color Color {  get; set; }
        public int NumeroMovimientos { get; set; }
        public char? PosiciónHorizontal { get; set; } 
        public int? PosiciónVertical { get; set; }
        public bool EnJuego { get; set; }



        //public enum TipoFicha { 
        //    Unknow = 0,
        //    P = 1, 
        //    K = 2, 
        //    Q = 3, 
        //    R = 4, 
        //    N = 5, 
        //    B = 6 
        //}
        //public enum ColorFicha {
        //    //Unknow = 0,
        //    White = 0, 
        //    Black = 1
        //}
    }
}
