using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Model
{
    public class Reina : Ficha
    {
        public Reina(Color color) : base(color)
        {
            Simbolo = 'Q';
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
