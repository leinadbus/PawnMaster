using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Model
{
    public class Peon : Ficha
    {
        public Peon(Color color) : base(color)
        {
            Simbolo = 'p';
        }


        public override bool ValidarPosicion (Casilla casillaEnLaQueEstoy, Casilla casillaALaQuePretendoMoverme)
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

            if (DiferenciaPosicionesFilas == 1 || DiferenciaPosicionesFilas == 2 || DiferenciaPosicionesFilas == -1 || DiferenciaPosicionesFilas == -2)  //n1 La cantidad de casillas es correcta?
            {
                if (Color == Color.Blanco)
                {
                    if (NumeroMovimientos == 0 && DiferenciaPosicionesFilas == 2 && DiferenciaPosicionesColumnas == 0)
                    {
                        sePodriaMover = true;
                    }
                    else if (NumeroMovimientos == 0 && DiferenciaPosicionesFilas == 1 && DiferenciaPosicionesColumnas == 0 )
                    {
                        sePodriaMover = true;
                    }
                }
                else
                {
                    if (NumeroMovimientos == 0 && DiferenciaPosicionesFilas == -2 && DiferenciaPosicionesColumnas == 0)
                    {
                        sePodriaMover = true;
                    }
                    else if (NumeroMovimientos == 0 && DiferenciaPosicionesFilas == -1 && DiferenciaPosicionesColumnas == 0)
                    {
                        sePodriaMover = true;
                    }
                }
            }
            return sePodriaMover;
        }


        public override bool ValidarDireccion(Casilla casillaEnLaQueEstoy, Casilla casillaALaQuePretendoMoverme)
        {
            bool sePodriaMover = false;

            //Posicion Inicial
            var FilaPosicionActual = casillaEnLaQueEstoy.Coordenadas.PosicionVertical;

            //Posicion Final
            var FilaPosicionfinal = casillaALaQuePretendoMoverme.Coordenadas.PosicionVertical;

            //Diferencia de filas (Dirección)
            var DiferenciaPosicionesFilas = FilaPosicionfinal - FilaPosicionActual;

            if (Color == Color.Blanco && SaberSiElMovimientoEsPositivo(DiferenciaPosicionesFilas))
            {
                    sePodriaMover = true;
            }
            else if (Color == Color.Negro && !SaberSiElMovimientoEsPositivo(DiferenciaPosicionesFilas))
            {
                    sePodriaMover = true;
            }

            return sePodriaMover;
        }

    }
}
