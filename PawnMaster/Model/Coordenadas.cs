using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Model
{
    public class Coordenadas : IEquatable<Coordenadas>
    {
        public int PosicionVertical { get; set; }
        public int PosicionHorizontal { get; set; }

        public Coordenadas(int vertical, int horizontal)
        {
            this.PosicionVertical = vertical;
            this.PosicionHorizontal = horizontal;
        }

        public bool Equals(Coordenadas? obj)
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
