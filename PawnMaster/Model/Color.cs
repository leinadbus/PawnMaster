using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Model
{
    public class Color
    {
        private char LetraRepresentante { get; set; }
        private Color(char letra)
        {
            LetraRepresentante = letra;
        }

        public override string ToString()
        {
            return LetraRepresentante.ToString();
        }

        public static readonly Color Blanco = new Color('w');
        public static readonly Color Negro = new Color('b');
    }
}
