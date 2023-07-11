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

        public override bool ValidarDireccion(Casilla inicio, Casilla Final)
        {
            throw new NotImplementedException();
        }
        public override bool ValidarPosicion(Casilla casillaEnLaQueEstoy, Casilla casillaALaQuePretendoMoverme)
        {
            throw new NotImplementedException();
        }
    }
}
