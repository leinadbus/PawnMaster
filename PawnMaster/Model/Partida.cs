using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnMaster.Model;

namespace PawnMaster.Model
{
    public class Partida
    {
        public Guid Identificador { get; set; }

        public DateTime Date { get; set; }

        public Tablero Tablero { get; set; }

        public Jugador JugadorBlanco { get; set; }
        public Jugador JugadorNegro { get; set; }

        public List<string> ListaDeMovimientos { get; set; }


        public Partida(Jugador jugadorBlanco, Jugador jugadorNegro)
        {
            Identificador = Guid.NewGuid();
            Date = DateTime.Now;
            JugadorBlanco = jugadorBlanco;
            JugadorNegro = jugadorNegro;
            Tablero = new Tablero();
            ListaDeMovimientos = new List<string>();
        }

        public void CrearPartidaDeAjedrez ()
        {

            //Fichas Negras
            var PeonNegro0 = new Peon(Color.Negro);
            var PeonNegro1 = new Peon(Color.Negro);
            var PeonNegro2 = new Peon(Color.Negro);
            var PeonNegro3 = new Peon(Color.Negro);
            var PeonNegro4 = new Peon(Color.Negro);
            var PeonNegro5 = new Peon(Color.Negro);
            var PeonNegro6 = new Peon(Color.Negro);
            var PeonNegro7 = new Peon(Color.Negro);

            var ReyNegro = new Rey(Color.Negro);
            var ReinaNegra = new Reina(Color.Negro);

            var TorreNegra0 = new Torre(Color.Negro);
            var TorreNegra1 = new Torre(Color.Negro);

            var CaballoNegro0 = new Caballo(Color.Negro);
            var CaballoNegro1 = new Caballo(Color.Negro);

            var AlfinNegro0 = new Alfil(Color.Negro);
            var AlfinNegro1 = new Alfil(Color.Negro);


            //Fichas Blancas
            var PeonBlanco0 = new Peon(Color.Blanco);
            var PeonBlanco1 = new Peon(Color.Blanco);
            var PeonBlanco2 = new Peon(Color.Blanco);
            var PeonBlanco3 = new Peon(Color.Blanco);
            var PeonBlanco4 = new Peon(Color.Blanco);
            var PeonBlanco5 = new Peon(Color.Blanco);
            var PeonBlanco6 = new Peon(Color.Blanco);
            var PeonBlanco7 = new Peon(Color.Blanco);

            var ReyBlanco = new Rey(Color.Blanco);
            var ReinaBlanco = new Reina(Color.Blanco);

            var TorreBlanco0 = new Torre(Color.Blanco);
            var TorreBlanco1 = new Torre(Color.Blanco);

            var CaballoBlanco0 = new Caballo(Color.Blanco);
            var CaballoBlanco1 = new Caballo(Color.Blanco);

            var AlfinBlanco0 = new Alfil(Color.Blanco);
            var AlfinBlanco1 = new Alfil(Color.Blanco);

            //Posicionamiento de las fichas Negras
            this.Tablero.AñadirFichaAlTablero(new Coordenada('A', 8), TorreNegra0);
            this.Tablero.AñadirFichaAlTablero(new Coordenada('B', 8), CaballoNegro0);
            this.Tablero.AñadirFichaAlTablero(new Coordenada('C', 8), AlfinNegro0);
            this.Tablero.AñadirFichaAlTablero(new Coordenada('D', 8), ReinaNegra);
            this.Tablero.AñadirFichaAlTablero(new Coordenada('E', 8), ReyNegro);
            this.Tablero.AñadirFichaAlTablero(new Coordenada('F', 8), AlfinNegro1);
            this.Tablero.AñadirFichaAlTablero(new Coordenada('G', 8), CaballoNegro1);
            this.Tablero.AñadirFichaAlTablero(new Coordenada('H', 8), TorreNegra1);

            this.Tablero.AñadirFichaAlTablero(new Coordenada('A', 7), PeonNegro0);
            this.Tablero.AñadirFichaAlTablero(new Coordenada('B', 7), PeonNegro1);
            this.Tablero.AñadirFichaAlTablero(new Coordenada('C', 3), PeonNegro2);
            this.Tablero.AñadirFichaAlTablero(new Coordenada('D', 7), PeonNegro3);
            this.Tablero.AñadirFichaAlTablero(new Coordenada('E', 7), PeonNegro4);
            this.Tablero.AñadirFichaAlTablero(new Coordenada('F', 7), PeonNegro5);
            this.Tablero.AñadirFichaAlTablero(new Coordenada('G', 7), PeonNegro6);
            this.Tablero.AñadirFichaAlTablero(new Coordenada('H', 7), PeonNegro7);


            ////Posicionamiento de las fichas Blancas
            this.Tablero.AñadirFichaAlTablero(new Coordenada('A', 1), TorreBlanco0);
            this.Tablero.AñadirFichaAlTablero(new Coordenada('B', 1), CaballoBlanco0);
            this.Tablero.AñadirFichaAlTablero(new Coordenada('C', 1), AlfinBlanco0);
            this.Tablero.AñadirFichaAlTablero(new Coordenada('D', 1), ReinaBlanco);
            this.Tablero.AñadirFichaAlTablero(new Coordenada('E', 1), ReyBlanco);
            this.Tablero.AñadirFichaAlTablero(new Coordenada('F', 1), AlfinBlanco1);
            this.Tablero.AñadirFichaAlTablero(new Coordenada('G', 1), CaballoBlanco1);
            this.Tablero.AñadirFichaAlTablero(new Coordenada('H', 1), TorreBlanco1);

            this.Tablero.AñadirFichaAlTablero(new Coordenada('A', 2), PeonBlanco0);
            this.Tablero.AñadirFichaAlTablero(new Coordenada('B', 2), PeonBlanco1);
            this.Tablero.AñadirFichaAlTablero(new Coordenada('C', 2), PeonBlanco2);
            this.Tablero.AñadirFichaAlTablero(new Coordenada('D', 2), PeonBlanco3);
            this.Tablero.AñadirFichaAlTablero(new Coordenada('E', 2), PeonBlanco4);
            this.Tablero.AñadirFichaAlTablero(new Coordenada('F', 2), PeonBlanco5);
            this.Tablero.AñadirFichaAlTablero(new Coordenada('G', 2), PeonBlanco6);
            this.Tablero.AñadirFichaAlTablero(new Coordenada('H', 2), PeonBlanco7);

        }

        public bool existeFichaEnCasillaDestino (Casilla casillaDestino)
        {
            if(casillaDestino.FichaActual == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool FichaEnCasillaDestinoEsDelMismoColor (Ficha fichaActual, Ficha fichaDestino)
        {
            if(fichaActual.Color == fichaDestino.Color)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public (char, string, string) RecogerDatosDelMovimientoDelUsuario (String movimientoUsuario)
        //{
        //    char piezaAMover = ' ';
        //    string nuevomovimiento = "";
        //    //Está vacio??
        //    if (!string.IsNullOrEmpty(movimientoUsuario))
        //        {
        //        //Eliminamos cualquier espacio en blanco que pueda haber
        //        movimientoUsuario = movimientoUsuario.Trim();
        //        movimientoUsuario = movimientoUsuario.Replace(" ", "");
                

        //            //Empieza con una mayúscula?
        //            if (char.IsUpper(movimientoUsuario[0]))
        //            {
        //            //Le quitamos la primera posición que es mayúscula (La podemos guardar en alguna variable)
        //            piezaAMover = movimientoUsuario[0];
                        
        //                for (int i = 1; i < movimientoUsuario.Length; i++)
        //                {
        //                    nuevomovimiento += movimientoUsuario[i];
        //                }
        //            }
        //            else
        //            {
        //                nuevomovimiento = movimientoUsuario;
        //            }

        //            //Contiene una x??
        //            if (nuevomovimiento.Contains("x"))
        //            {
        //                //El tratamiento de separación es diferente si contiene una x de no
        //                //El fín es diferente, ya que no movemos, atacamos

        //                string[] movimientos = nuevomovimiento.Split("x");
        //                string casillaInicial = movimientos[0];
        //                string casillaFinalAComer = movimientos[1];
        //                Console.WriteLine("Pieza a mover: " + piezaAMover);
        //                Console.WriteLine("Casilla Inicial: " + casillaInicial);
        //                Console.WriteLine("Casilla a comer: " + casillaFinalAComer);
        //            return (piezaAMover, casillaInicial, casillaFinalAComer);
        //        }
        //            else
        //            {
        //                //Este fín es solamente moverse, no comer
        //                int mitad = nuevomovimiento.Length / 2;
        //                string parte1 = nuevomovimiento.Substring(0, mitad);
        //                string parte2 = nuevomovimiento.Substring(mitad);
        //                Console.WriteLine("Pieza a mover: " + piezaAMover);
        //                Console.WriteLine("Casilla Inicial: " + parte1);
        //                Console.WriteLine("Casilla Destino: " + parte2);
        //            return (piezaAMover, parte1, parte2);
        //        }
        //        }

        //        else
        //        {
        //            Console.WriteLine("Por favor introduzca un movimiento adecuado");
        //        }
        //    return (piezaAMover, string.Empty, string.Empty);
        //}

        public bool ComprobarSiEsCaptura(String movimientoUsuario)
        {
                if (movimientoUsuario.Contains('x') || movimientoUsuario.Contains('X'))
                {
                    return true;
                }
                else return false;
        }

        public char RecogerCaracterCaptura(String movimientoUsuario)
        {
            if (movimientoUsuario.Contains('x') )
            {
                return 'x';
            }
            else return 'X'; 
        }

        public (char, string) RecogerPiezaYMovimientoOCaptura (String movimientoUsuario)
        {
            char piezaAMover = ' ';
            string nuevomovimiento = "";
            if (char.IsUpper(movimientoUsuario[0]))
            {
                //Le quitamos la primera posición que es mayúscula (La podemos guardar en alguna variable)
                piezaAMover = movimientoUsuario[0];

                for (int i = 1; i < movimientoUsuario.Length; i++)
                {
                    nuevomovimiento += movimientoUsuario[i];
                }
            }
            else
            {
                nuevomovimiento = movimientoUsuario;
            }
            return (piezaAMover, nuevomovimiento);
        }


        public ( string, string) RecogerDatosDeLaCaptura(String nuevomovimiento, char caracterCaptura)
        {
            string[] movimientos = nuevomovimiento.Split(caracterCaptura);
            string casillaInicial = movimientos[0];
            string casillaFinalAComer = movimientos[1];

            return (casillaInicial, casillaFinalAComer);
        }

        public (string, string) RecogerDatosDelMovimiento(String nuevomovimiento)
        {
            int mitad = nuevomovimiento.Length / 2;
            string parte1 = nuevomovimiento.Substring(0, mitad);
            string parte2 = nuevomovimiento.Substring(mitad);

            return (parte1, parte2);

        }

        public bool ComprobarMovimientoCapturaPeon (Casilla casillaEnLaQueEstoy, Casilla casillaALaQuePretendoMoverme)
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
