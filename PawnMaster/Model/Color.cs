using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Model
{
    public class Color
    {
        public char LetraRepresentante { get; set; }
        public Color()
        {
            LetraRepresentante = 'x';
        }
        public Color(char letra)
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
