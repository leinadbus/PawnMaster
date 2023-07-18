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

            //if(NumeroMovimientos == 0 && DiferenciaPosicionesFilas == 1 || DiferenciaPosicionesFilas == 2) { }
            if (Color == Color.Blanco && NumeroMovimientos == 0 && DiferenciaPosicionesColumnas == 0 && (DiferenciaPosicionesFilas == 1 || DiferenciaPosicionesFilas == 2))
            {
                sePodriaMover = true;
            }
            else if (Color == Color.Blanco && NumeroMovimientos != 0 && DiferenciaPosicionesColumnas == 0 && DiferenciaPosicionesFilas == 1)
            {
                sePodriaMover = true;
            }
            else if (Color == Color.Negro && NumeroMovimientos == 0 && DiferenciaPosicionesColumnas == 0 && (DiferenciaPosicionesFilas == -1 || DiferenciaPosicionesFilas == -2))
            {
                sePodriaMover = true;
            }
            else if (Color == Color.Negro && NumeroMovimientos != 0 && DiferenciaPosicionesColumnas == 0 && DiferenciaPosicionesFilas == -1)
            {
                sePodriaMover = true;
            }

            return sePodriaMover;
        }

        public override bool validarCaptura(Casilla casillaEnLaQueEstoy, Casilla casillaALaQuePretendoMoverme)
        {
            //Mover a clase PEON ------------------------------------------------------------------------------------------------------------------
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
                if (casillaEnLaQueEstoy.FichaActual != null)
                {

                    if (casillaEnLaQueEstoy.FichaActual.Color == Color.Blanco)
                    {

                        if (DiferenciaPosicionesFilas == 1 && (DiferenciaPosicionesColumnas == 1 || DiferenciaPosicionesColumnas == -1))
                        {
                            sePodriaMover = true;
                        }
                    }
                    else
                    {

                        if (DiferenciaPosicionesFilas == -1 && (DiferenciaPosicionesColumnas == 1 || DiferenciaPosicionesColumnas == -1))
                        {
                            sePodriaMover = true;
                        }
                    }
                }
            }
            return sePodriaMover;
        }

    }
}
