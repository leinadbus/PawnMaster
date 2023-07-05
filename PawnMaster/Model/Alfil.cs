using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Model
{
    internal class Alfil : Ficha
    {
        public Alfil(Color color) : base(color)
        {
            Simbolo = 'B';
        }
    }
}
