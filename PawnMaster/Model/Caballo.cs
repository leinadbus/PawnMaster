using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Model
{
    internal class Caballo : Ficha
    {
        public Caballo(Color color) : base(color)
        {
            Simbolo = 'N';
        }
    }
}
