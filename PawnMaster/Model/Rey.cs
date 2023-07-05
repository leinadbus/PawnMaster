using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Model
{
    internal class Rey : Ficha
    {
        public Rey(Color color) : base(color)
        {
            Simbolo = 'K';
        }
    }
}
