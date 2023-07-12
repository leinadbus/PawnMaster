using PawnMaster.Model;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace PawnMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {


            string comer = "Pb2xd3";
            string mover = "Pb2b4";
            string comersincasilla = "xb4";
            string comersinficha = "b2xd3";
            string moversinficha = "b2d3";


            Jugador jugador = new Jugador();
            Jugador jugadora = new Jugador();
            Partida partida = new(jugador, jugadora);
            partida.CrearPartidaDeAjedrez();
            partida.Tablero.MostrarEstadoDelTablero();


            string movimientoUsuario;
            do
            {
                movimientoUsuario = Console.ReadLine();

                if (partida.ComprobarSiEsCaptura(movimientoUsuario))
                {
                    Console.WriteLine("Esto es un movimiento de captura");
                    //Recogemos la pieza si nos la han dado
                    (char pieza, string movimiento) = partida.RecogerPiezaYMovimientoOCaptura(movimientoUsuario);

                    //Recogemos el caracter de captura 'x' ó 'X' (Este paso puede que desaparezca)
                    char caracterCaptura = partida.RecogerCaracterCaptura(movimientoUsuario);

                    //Recogemos los datos del movimiento por separado en dos variables
                    (string casillaInicio, string casillaDestino) = partida.RecogerDatosDeLaCaptura(movimiento, caracterCaptura);

                    //Mostramos para comprobar
                    Console.WriteLine("La ficha es: " + pieza);
                    Console.WriteLine("La casilla de Inicio es: " + casillaInicio);
                    Console.WriteLine("La casilla de Destino es: " + casillaDestino);

                    //Separamos las coordenadas de los datos (Esto podría ser un método)
                    char verticalInicio = char.ToUpper(casillaInicio[0]);
                    int horizontalInicio = casillaInicio[1] - '0';


                    char verticalDestino = char.ToUpper(casillaDestino[0]);
                    int horizontalDestino = casillaDestino[1] - '0';

                    Casilla casillaInicioSeleccionada = partida.Tablero.SeleccionarCasilla(verticalInicio, horizontalInicio);
                    Casilla casillaDestinoSeleccionada = partida.Tablero.SeleccionarCasilla(verticalDestino, horizontalDestino);

                    ////Comprobamos si en la casilla destino existe una ficha enemiga ////Comprobamos si el Peón puede moverse hasta donde nos piden en una captura
                    if (partida.existeFichaEnCasillaDestino(casillaDestinoSeleccionada) && casillaInicioSeleccionada.FichaActual.Color != casillaDestinoSeleccionada.FichaActual.Color && partida.ComprobarMovimientoCapturaPeon(casillaInicioSeleccionada, casillaDestinoSeleccionada))
                    {
                        Console.WriteLine("Completamos movimiento");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("El movimiento no es posible");
                    }

                    //if Todos los pasos completados, procedemos a mover la ficha para captura

                    Console.WriteLine();
                    partida.Tablero.MostrarEstadoDelTablero();
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Movimiento de Desplazamiento:");
                    (char pieza, string movimiento) = partida.RecogerPiezaYMovimientoOCaptura(movimientoUsuario);
                    (string casillaInicio, string casillaDestino) = partida.RecogerDatosDelMovimiento(movimiento);
                    Console.WriteLine("La ficha es: " + pieza);
                    Console.WriteLine("La casilla de Inicio es: " + casillaInicio);
                    Console.WriteLine("La casilla de Destino es: " + casillaDestino);

                    char verticalInicio = char.ToUpper(casillaInicio[0]);
                    int horizontalInicio = casillaInicio[1] - '0';


                    char verticalDestino = char.ToUpper(casillaDestino[0]);
                    int horizontalDestino = casillaDestino[1] - '0';

                    Casilla casillaInicioSeleccionada = partida.Tablero.SeleccionarCasilla(verticalInicio, horizontalInicio);
                    Casilla casillaDestinoSeleccionada = partida.Tablero.SeleccionarCasilla(verticalDestino, horizontalDestino);

                    if (!partida.existeFichaEnCasillaDestino(casillaDestinoSeleccionada) && casillaInicioSeleccionada.FichaActual.ValidarDireccion(casillaInicioSeleccionada, casillaDestinoSeleccionada) && casillaInicioSeleccionada.FichaActual.ValidarPosicion(casillaInicioSeleccionada, casillaDestinoSeleccionada))
                    {
                        Console.WriteLine("Se puede mover");
                    }
                    else
                    {
                        Console.WriteLine("NO Se puede mover");
                    }
                    Console.WriteLine();
                    partida.Tablero.MostrarEstadoDelTablero();
                    Console.WriteLine();
                }

            } while (movimientoUsuario != "-1");

        }

    }
}