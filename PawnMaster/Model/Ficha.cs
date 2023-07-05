using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnMaster;

namespace PawnMaster.Model
{
    public class Ficha
    {
        public Color color { get; }

        public  char simbolo { get; set; }

        public int numeroMovimientos { get; set; } = 0;

        //public int[] posicionInicial { get; set; }
        public int[] posicionActual { get; set; }

        public Ficha(Color color)
        {
            this.color = color;
        }

        public void aumentarNumeroMovimientos()
        {
            numeroMovimientos++;
        }
    }
}
