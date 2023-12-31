﻿using System;
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
        public List<Ficha> Cementerio = new();


        public Tablero()
        {
            Estado = "En curso";
            TableroJuego = CrearNuevoTablero();
        }

        /// <summary>
        /// Mueve una ficha (si existe) de origen a destino. Si en destino hay ficha, la captura y la manda al cementerio.
        /// </summary>
        /// <param name="origen">Coordenadas de origen</param>
        /// <param name="destino">Coordenadas de destino</param>
        public void MoverFicha(Coordenada origen, Coordenada destino)
        {
            if (TableroJuego.TryGetValue(origen, out var casillaOrigen)
                && TableroJuego.TryGetValue(destino, out var casillaDestino)
                && casillaOrigen.Tengoficha())
            {
                if (casillaDestino.Tengoficha())
                {
                    EliminarFicha(destino);
                }
                var ficha = casillaOrigen.FichaActual;
                casillaOrigen.EliminarFicha();
                casillaDestino.SetFichaActual(ficha);
            }
        }

        public void EliminarFicha(Coordenada coordenada)
        {
            if (TableroJuego.TryGetValue(coordenada, out var casilla))
            {
                var ficha = casilla.FichaActual;
                casilla.EliminarFicha();
                Cementerio.Add(ficha);
            }
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

        public void EliminarTodasFichasTablero ()
        {
            for (char caracter = 'A'; caracter <= 'H'; caracter++)
            {
                for (int numero = 1; numero < 9; numero++)
                {
                    Coordenada origen = new Coordenada(caracter, numero);
                    if (TableroJuego.TryGetValue(origen, out var casillaOrigen))
                    {
                        if (casillaOrigen.Tengoficha())
                        {
                            casillaOrigen.EliminarFicha();
                        }
                    }
                }
            }
        }

        public bool SaberSiHayFichasEnElCaminoParaTorre(Casilla casillaEnLaQueEstoy, Casilla casillaALaQuePretendoMoverme)
        {
            bool sePodriaMover = true;

            //Posicion Inicial
            var FilaPosicionActual = casillaEnLaQueEstoy.Coordenadas.PosicionVertical;
            var ColumnaPosicionActual = casillaEnLaQueEstoy.Coordenadas.PosicionHorizontal;

            //Posicion Final
            var FilaPosicionfinal = casillaALaQuePretendoMoverme.Coordenadas.PosicionVertical;
            var ColumnaPosicionFinal = casillaALaQuePretendoMoverme.Coordenadas.PosicionHorizontal;

            //Si las filas tienen el mismo número, el movimiento es recto en sentido columnas
            if (FilaPosicionActual == FilaPosicionfinal)
            {
                //Si el movimiento es positivo, es decir, que el movimiento vaya en aumentos de numeros
                if (ColumnaPosicionFinal - ColumnaPosicionActual > 0)
                {
                    for (char ComprobandoFilas = ++ColumnaPosicionActual; ComprobandoFilas < ColumnaPosicionFinal; ComprobandoFilas++)
                    {
                        var casillaComprobada = SeleccionarCasilla(ComprobandoFilas, FilaPosicionActual);

                        if (casillaComprobada.Tengoficha())
                        {
                            sePodriaMover = false;
                            return sePodriaMover;
                        }
                    }
                }
                //Si el movimiento es negativo, es decir, que el movimiento vaya en decremento de numeros
                if (ColumnaPosicionFinal - ColumnaPosicionActual < 0)
                {
                    for (char ComprobandoFilas = --ColumnaPosicionActual; ComprobandoFilas > ColumnaPosicionFinal; ComprobandoFilas--)
                    {
                        var casillaComprobada = SeleccionarCasilla(ComprobandoFilas, FilaPosicionActual);

                        if (casillaComprobada.Tengoficha())
                        {
                            sePodriaMover = false;
                            return sePodriaMover;
                        }
                    }
                }
            }
            else if (ColumnaPosicionActual == ColumnaPosicionFinal)
            {
                if(FilaPosicionfinal-FilaPosicionActual > 0)
                {
                    for (int ComprobandoColumnas = ++FilaPosicionActual; ComprobandoColumnas < FilaPosicionfinal; ComprobandoColumnas++)
                    {
                        var casillaComprobada = SeleccionarCasilla(ColumnaPosicionActual, ComprobandoColumnas);

                        if (casillaComprobada.Tengoficha())
                        {
                            sePodriaMover = false;
                            return sePodriaMover;
                        }
                    }
                }
                if (FilaPosicionfinal - FilaPosicionActual < 0)
                {
                    for (int ComprobandoColumnas = --FilaPosicionActual; ComprobandoColumnas > FilaPosicionfinal; ComprobandoColumnas--)
                    {
                        var casillaComprobada = SeleccionarCasilla(ColumnaPosicionActual, ComprobandoColumnas);

                        if (casillaComprobada.Tengoficha())
                        {
                            sePodriaMover = false;
                            return sePodriaMover;
                        }
                    }
                }
            }

            return sePodriaMover;
        }

    }
}
