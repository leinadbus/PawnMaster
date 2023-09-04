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


            //si columna es 0 fila puede ser infinito desde 1 o -1 y viceversa
            if (DiferenciaPosicionesFilas == 0 && (DiferenciaPosicionesColumnas <0 || DiferenciaPosicionesColumnas >0))
            {
                sePodriaMover = true;
            }
            else if (DiferenciaPosicionesColumnas == 0 && (DiferenciaPosicionesFilas < 0 || DiferenciaPosicionesFilas > 0))
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
