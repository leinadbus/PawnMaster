using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Model
{
    public class Tablero
    {
        private const int PrimeraLinea = 1;
        private const char PrimeraColumna = 'A';
        private const int UltimaLinea = 8;
        private const char UltimaColumna = 'H';

        public string Estado { get; set; }
        public Dictionary<Coordenada, Casilla> TableroJuego { get; set; }
        public Tablero()
        {
            Estado = "En curso";
            TableroJuego = CrearNuevoTablero();
        }

        private Dictionary<Coordenada, Casilla> CrearNuevoTablero()
        {
            var tablero = new Dictionary<Coordenada, Casilla>();

            for (int fila = UltimaLinea; fila >= PrimeraLinea; fila--)
            {
                for (char columna = PrimeraColumna; columna <= UltimaColumna; columna++)
                {
                    if (columna % 2 == 0 && fila % 2 == 0)
                    {
                        var ejemplo = new Coordenada(columna, fila);
                        tablero.Add(ejemplo, new Casilla(ejemplo, Color.Blanco));
                    }
                    else if (columna % 2 == 0 && fila % 2 != 0)
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

        public void MostrarEstadoDelTablero()
        {
            var charList = new List<char>();
            var totalColumnas = (UltimaColumna - PrimeraColumna) + 1;
            // Número de digitos que tiene el total de columnas. P.e. para 140 serían 3 digitos.
            var numeroDigitos = Convert.ToString(totalColumnas, CultureInfo.InvariantCulture).Length;
            // Con el número de digitos puedo hacer el padding necesario para rellenar lo que falta
            var paddingInicial = string.Concat(Enumerable.Repeat(" ", numeroDigitos));

            for (var letra = PrimeraColumna; letra <= UltimaColumna; letra++)
            {
                charList.Add(letra);
            }

            // Pintar letras de arriba
            var columnLegend = paddingInicial + "   " + string.Join("   ", charList);
            var separadorInicial = paddingInicial + " " + string.Concat(Enumerable.Repeat(" ---", totalColumnas));

            Console.WriteLine(columnLegend);
            Console.WriteLine(separadorInicial);

            for (int horizontal = UltimaLinea; horizontal >= PrimeraLinea; horizontal--)
            {
                // Cuanto más ancho es el número a pintar, menos padding hay que meter
                var digitos = Convert.ToString(horizontal, CultureInfo.InvariantCulture).Length;
                var padding = string.Concat(Enumerable.Repeat(" ", numeroDigitos - digitos));
                // Pintar el número de fila junto al padding
                Console.Write(padding + horizontal);

                for (char vertical = PrimeraColumna; vertical <= UltimaColumna; vertical++)
                {
                    var corrd = new Coordenada(vertical, horizontal);
                    if (TableroJuego.TryGetValue(corrd, out var casilla))
                    {
                        // Pintar la casilla
                        Console.Write(" | ");

                        if (casilla.FichaActual != null)
                        {
                            Console.ForegroundColor = casilla.FichaActual.Color == Color.Blanco ? ConsoleColor.Cyan : ConsoleColor.Magenta;
                            Console.Write(casilla.FichaActual.Simbolo);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                }
                // Pintar el final de la fila junto al número de fila y el separador entre filas
                var separador = paddingInicial + " " + string.Concat(Enumerable.Repeat(" ---", totalColumnas));
                Console.Write(" | " + horizontal);
                Console.WriteLine();
                Console.WriteLine(separador);
            }

            // Pintar letras de abajo
            Console.WriteLine(columnLegend);

            Console.WriteLine();
        }

        public Casilla SeleccionarCasilla(char vertical, int Horizontal)
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

    }
}
