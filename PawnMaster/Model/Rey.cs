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


            //Existen 8 posibilidades de combinaciones para el movimiento del rey, ente las coordenadas -1,-1 hasta 1,1 quitando la 0,0 ya que es la coordenada donde se encuentra
            if (DiferenciaPosicionesFilas == 0 && (DiferenciaPosicionesColumnas == 1 || DiferenciaPosicionesColumnas == -1))
            {
                sePodriaMover = true;
            }
            else if (DiferenciaPosicionesFilas == 1 && (DiferenciaPosicionesColumnas == 1 || DiferenciaPosicionesColumnas == 0 || DiferenciaPosicionesColumnas == -1))
            {
                sePodriaMover = true;
            }
            else if (DiferenciaPosicionesFilas == -1 && (DiferenciaPosicionesColumnas == 1 || DiferenciaPosicionesColumnas == 0 || DiferenciaPosicionesColumnas == -1))
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
