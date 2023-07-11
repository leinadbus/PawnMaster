using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Model
{
    public class Tablero
    {
        public string Estado { get; set; }
        public Dictionary<Coordenada,Casilla> TableroJuego { get; set; }
        public Tablero()
        {
            Estado = "En curso";
            TableroJuego = CrearNuevoTablero();
        }

        private Dictionary<Coordenada, Casilla> CrearNuevoTablero()
        {
            //var tablero = new List<Casilla>();
            var tablero = new Dictionary<Coordenada, Casilla>();

            for (int fila = 8; fila >= 1; fila--)
            {
                for (char columna = 'A'; columna < 73; columna++)
                {
                    if (columna % 2 == 0 && fila % 2 == 0)
                    {
                        var ejemplo = new Coordenada(columna,fila);
                        tablero.Add(ejemplo, new Casilla(ejemplo, Color.Blanco));
                    }
                    else if(columna % 2 == 0 && fila % 2 != 0)
                    {
                        var ejemplo = new Coordenada(columna, fila);
                        tablero.Add(ejemplo, new Casilla(ejemplo, Color.Negro));
                    }
                    else if (columna % 2 != 0 && fila % 2 != 0)
                    {
                        var ejemplo = new Coordenada(columna, fila);
                        tablero.Add(ejemplo, new Casilla(ejemplo, Color.Blanco));
                    }
                    else if (columna % 2 != 0 && fila % 2 == 0)
                    {
                        var ejemplo = new Coordenada(columna, fila);
                        tablero.Add(ejemplo, new Casilla(ejemplo, Color.Negro));
                    }
                }
            }
          
            return tablero;
        }


        public void MostrarTableroEnColorDeCasillas()
        {
            foreach (KeyValuePair<Coordenada, Casilla> par in this.TableroJuego)
            {
                Console.Write(par.Value.Color  +" | ");
                if(par.Value.Coordenadas.PosicionHorizontal == 7)
                {
                    Console.WriteLine();
                    Console.WriteLine("-- --- --- --- --- --- --- ---");

                }
            }
            
        }

        public void MostrarTableroEnCoordenadas()
        {
            foreach (KeyValuePair<Coordenada, Casilla> par in this.TableroJuego)
            {
                Console.Write(par.Value.Coordenadas.PosicionHorizontal + " " + par.Value.Coordenadas.PosicionVertical + " | ");
                if (par.Value.Coordenadas.PosicionHorizontal == 72)
                {
                    Console.WriteLine();
                    Console.WriteLine("---- ----- ----- ----- ----- ----- ----- -----");

                }
            }
        }

        public void MostrarTableroEnKeys()
        {
            foreach (KeyValuePair<Coordenada, Casilla> par in this.TableroJuego)
            {
                Console.Write(par.Key.PosicionHorizontal + " " + par.Value.Coordenadas.PosicionVertical + " | ");
                if (par.Value.Coordenadas.PosicionHorizontal == 72)
                {
                    Console.WriteLine();
                    Console.WriteLine("---- ----- ----- ----- ----- ----- ----- -----");

                }
            }
        }

        public void MostrarEstadoDelTablero()
        {

            var arrayLetras = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
            foreach (var letra in arrayLetras)
            {
                Console.Write("  " + letra + " ");
            }

            Console.WriteLine();
            Console.WriteLine(" --- --- --- --- --- --- --- ---");
            Console.Write("| ");

            int numeroFila = 8;
            foreach (KeyValuePair<Coordenada, Casilla> par in this.TableroJuego)
            {
                if (par.Value.FichaActual == null)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("  | ");
                }
                else
                {
                    if(par.Value.FichaActual.Color == Color.Blanco)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(par.Value.FichaActual.Simbolo );
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write( " | ");
                    }
                    else if (par.Value.FichaActual.Color == Color.Negro)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(par.Value.FichaActual.Simbolo);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" | ");
                    }
                    //Console.Write(par.Value.FichaActual.Simbolo + " | ");
                }

                if (par.Value.Coordenadas.PosicionHorizontal == 72)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" " + numeroFila--);
                    Console.WriteLine();
                    Console.WriteLine(" --- --- --- --- --- --- --- ---" );
                    if (par.Value.Coordenadas.PosicionVertical >= 2)
                    {
                        Console.Write("| ");
                    }
                    

                }
            }
            Console.WriteLine();
        }

        public Casilla SeleccionarCasilla(char vertical,int Horizontal )
        {
            var Coordenadas = new Coordenada(vertical, Horizontal);

            return this.TableroJuego.GetValueOrDefault(Coordenadas);

        }

        public void AñadirFichaAlTablero(Coordenada coordenada, Ficha ficha)
        {
            if (this.TableroJuego.TryGetValue(coordenada, out var casilla))
            {
                casilla.SetFichaActual(ficha);
            }
            else
            {
                Console.WriteLine("Problemas en la función añadirFichaAlTablero()");
            }
        }

        ////This functions translate the movements into usefull notation
        //public int[] TraductorMovimiento(char columna, int fila)
        //{
        //    columna = char.ToUpper(columna);
        //    int columnaFinal = 0;
        //    switch (columna)
        //    {
        //        case 'A':
        //            columnaFinal = 1;
        //            break;
        //        case 'B':
        //            columnaFinal = 2;
        //            break;
        //        case 'C':
        //            columnaFinal = 3;
        //            break;
        //        case 'D':
        //            columnaFinal = 4;
        //            break;
        //        case 'E':
        //            columnaFinal = 5;
        //            break;
        //        case 'F':
        //            columnaFinal = 6;
        //            break;
        //        case 'G':
        //            columnaFinal = 7;
        //            break;
        //        case 'H':
        //            columnaFinal = 8;
        //            break;
        //    }
        //    int[] movimientoTraducido = { fila, columnaFinal };
        //    return movimientoTraducido;
        //}


    }
}
