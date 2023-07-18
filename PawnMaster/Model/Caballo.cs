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

        public override bool ValidarMovimiento(Casilla inicio, Casilla Final)
        {
            throw new NotImplementedException();
        }
        public override bool validarCaptura(Casilla casillaEnLaQueEstoy, Casilla casillaALaQuePretendoMoverme)
        {
            throw new NotImplementedException();
        }
    }
}
