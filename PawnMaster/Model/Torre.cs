using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Model
{
    internal class Torre : Ficha
    {
        public Torre(Color color) : base(color)
        {
            Simbolo = 'R';
        }
    }
}
