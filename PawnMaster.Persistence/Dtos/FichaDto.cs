using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Persistence.Dtos
{
    public class FichaDto
    {
        public int PosicionVertical { get; set; }
        public char PosicionHorizontal { get; set; }
        public char Simbolo { get; set; }
        public char LetraRepresentante { get; set; }
    }
}
