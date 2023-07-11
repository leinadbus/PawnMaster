using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Model
{
    public class Coordenada : IEquatable<Coordenada>
    {
        public int PosicionVertical { get; set; }
        public char PosicionHorizontal { get; set; }

        public Coordenada(char horizontal,int vertical)
        {
            this.PosicionVertical = vertical;
            this.PosicionHorizontal = horizontal;
        }

        public bool Equals(Coordenada? obj)
        {
            return obj != null &&
                   PosicionVertical == obj.PosicionVertical &&
                   PosicionHorizontal == obj.PosicionHorizontal;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PosicionVertical, PosicionHorizontal);
        }
    }
}
