using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Model
{
    public class Caballo : Ficha
    {
        public Caballo(Color color) : base(color)
        {
            Simbolo = 'N';
        }

        public override bool ValidarMovimiento(Casilla casillaEnLaQueEstoy, Casilla casillaALaQuePretendoMoverme)
        {
            bool sePodriaMover = false;

            //Posicion Inicial
            var FilaPosicionActual = casillaEnLaQueEstoy.Coordenadas.PosicionVertical;
            var ColumnaPosicionActual = casillaEnLaQueEstoy.Coordenadas.PosicionHorizontal;

            //Posicion Final
            var FilaPosicionfinal = casillaALaQuePretendoMoverme.Coordenadas.PosicionVertical;
            var ColumnaPosicionFinal = casillaALaQuePretendoMoverme.Coordenadas.PosicionHorizontal;

            //Diferencia de filas (Dirección)
            var DiferenciaPosicionesFilas = FilaPosicionfinal - FilaPosicionActual;
            var DiferenciaPosicionesColumnas = ColumnaPosicionFinal - ColumnaPosicionActual;

            if((DiferenciaPosicionesFilas == 1 || DiferenciaPosicionesFilas == -1) && (DiferenciaPosicionesColumnas == 2 || DiferenciaPosicionesColumnas == -2))
            {
                sePodriaMover = true;
            }
            if ((DiferenciaPosicionesFilas == 2 || DiferenciaPosicionesFilas == -2) && (DiferenciaPosicionesColumnas == 1 || DiferenciaPosicionesColumnas == -1)) 
            { 
                sePodriaMover = true; 
            }
            return sePodriaMover;
        }
        public override bool validarCaptura(Casilla casillaEnLaQueEstoy, Casilla casillaALaQuePretendoMoverme)
        {
            return ValidarMovimiento(casillaEnLaQueEstoy, casillaALaQuePretendoMoverme);
        }
    }
}
