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

        private Tablero Tablero { get; set; }

        public Jugador JugadorBlanco { get; set; }
        public Jugador JugadorNegro { get; set; }

        public List<string> ListaDeMovimientos { get; set; }

        public Jugador JugadorActual { get; set; }


        public Partida(Jugador jugadorBlanco, Jugador jugadorNegro)
        {
            Identificador = Guid.NewGuid();
            Date = DateTime.Now;
            JugadorBlanco = jugadorBlanco;
            JugadorNegro = jugadorNegro;
            JugadorActual = JugadorBlanco;
            Tablero = new Tablero();
            ListaDeMovimientos = new List<string>();
        }

        public void CrearPartidaDeAjedrez()
        {
            //Posicionamiento de las fichas Negras
            this.Tablero.AñadirFichaAlTablero(new Coordenada('A', 8), new Torre(Color.Negro));
            this.Tablero.AñadirFichaAlTablero(new Coordenada('B', 8), new Caballo(Color.Negro));
            this.Tablero.AñadirFichaAlTablero(new Coordenada('C', 8), new Alfil(Color.Negro));
            this.Tablero.AñadirFichaAlTablero(new Coordenada('D', 8), new Reina(Color.Negro));
            this.Tablero.AñadirFichaAlTablero(new Coordenada('E', 8), new Rey(Color.Negro));
            this.Tablero.AñadirFichaAlTablero(new Coordenada('F', 8), new Alfil(Color.Negro));
            this.Tablero.AñadirFichaAlTablero(new Coordenada('G', 8), new Caballo(Color.Negro));
            this.Tablero.AñadirFichaAlTablero(new Coordenada('H', 8), new Torre(Color.Negro));

            this.Tablero.AñadirFichaAlTablero(new Coordenada('A', 7), new Peon(Color.Negro));
            this.Tablero.AñadirFichaAlTablero(new Coordenada('B', 7), new Peon(Color.Negro));
            this.Tablero.AñadirFichaAlTablero(new Coordenada('C', 7), new Peon(Color.Negro));
            this.Tablero.AñadirFichaAlTablero(new Coordenada('D', 7), new Peon(Color.Negro));
            this.Tablero.AñadirFichaAlTablero(new Coordenada('E', 7), new Peon(Color.Negro));
            this.Tablero.AñadirFichaAlTablero(new Coordenada('F', 7), new Peon(Color.Negro));
            this.Tablero.AñadirFichaAlTablero(new Coordenada('G', 7), new Peon(Color.Negro));
            this.Tablero.AñadirFichaAlTablero(new Coordenada('H', 7), new Peon(Color.Negro));


            //Posicionamiento de las fichas Blancas
            this.Tablero.AñadirFichaAlTablero(new Coordenada('A', 1), new Torre(Color.Blanco));
            this.Tablero.AñadirFichaAlTablero(new Coordenada('B', 1), new Caballo(Color.Blanco));
            this.Tablero.AñadirFichaAlTablero(new Coordenada('C', 1), new Alfil(Color.Blanco));
            this.Tablero.AñadirFichaAlTablero(new Coordenada('D', 1), new Reina(Color.Blanco));
            this.Tablero.AñadirFichaAlTablero(new Coordenada('E', 1), new Rey(Color.Blanco));
            this.Tablero.AñadirFichaAlTablero(new Coordenada('F', 1), new Alfil(Color.Blanco));
            this.Tablero.AñadirFichaAlTablero(new Coordenada('G', 1), new Caballo(Color.Blanco));
            this.Tablero.AñadirFichaAlTablero(new Coordenada('H', 1), new Torre(Color.Blanco));

            this.Tablero.AñadirFichaAlTablero(new Coordenada('A', 2), new Peon(Color.Blanco));
            this.Tablero.AñadirFichaAlTablero(new Coordenada('B', 2), new Peon(Color.Blanco));
            this.Tablero.AñadirFichaAlTablero(new Coordenada('C', 2), new Peon(Color.Blanco));
            this.Tablero.AñadirFichaAlTablero(new Coordenada('D', 2), new Peon(Color.Blanco));
            this.Tablero.AñadirFichaAlTablero(new Coordenada('E', 2), new Peon(Color.Blanco));
            this.Tablero.AñadirFichaAlTablero(new Coordenada('F', 2), new Peon(Color.Blanco));
            this.Tablero.AñadirFichaAlTablero(new Coordenada('G', 2), new Peon(Color.Blanco));
            this.Tablero.AñadirFichaAlTablero(new Coordenada('H', 2), new Peon(Color.Blanco));

        }

        public Tablero RetornarTablero ()
        {
            return this.Tablero;
        }

        private void AlternarJugador()
        {
            if (JugadorActual == JugadorBlanco)
            {
                JugadorActual = JugadorNegro;
            }
            else
            {
                JugadorActual = JugadorBlanco;
            }
        }

        public void MostrarEstadoPartida()
        {
            Console.WriteLine($"TURNO DE {JugadorActual.Nombre}");
            Console.WriteLine($"ULTIMO MOVIMIENTO FUE: {ListaDeMovimientos.LastOrDefault()}");
            PintarCementerio();

            Tablero.MostrarEstadoDelTablero();
        }

        private void PintarCementerio()
        {
            Console.Write("PIEZAS CAPTURADAS: ");
            foreach (var pieza in Tablero.Cementerio)
            {
                Console.ForegroundColor = pieza.Color == Color.Blanco ? ConsoleColor.Cyan : ConsoleColor.Magenta;
                Console.Write(pieza.Simbolo);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" ");
            }
            Console.WriteLine();
        }

        private void RegistrarMovimiento(string movimiento)
        {
            ListaDeMovimientos.Add(movimiento);
        }

        public void EjecutarTurno(string notacion)
        {
            if (!Movimiento.ComprobarNotacionMovimientoEsValida(notacion))
            {
                // Si no es válido
                Console.WriteLine("Notación de movimiento incorrecta.");
                return;
            }

            var movimiento = new Movimiento(notacion);
            var casillaOrigen = Tablero.SeleccionarCasilla(movimiento.CoordenadaInicial.PosicionHorizontal, movimiento.CoordenadaInicial.PosicionVertical);
            var casillaDestino = Tablero.SeleccionarCasilla(movimiento.CoordenadaFinal.PosicionHorizontal, movimiento.CoordenadaFinal.PosicionVertical);

            if (!casillaOrigen.Tengoficha())
            {
                Console.WriteLine("Casilla seleccionada no contiene ninguna ficha");
                return;
            }
            //Si la ficha no coincide con la del movimiento
            if(char.ToUpper(movimiento.FichaAMover) != char.ToUpper(casillaOrigen.FichaActual.Simbolo))
            {
                Console.WriteLine("Ficha indicada no coincide con la que existe en la casilla");
                return;
            }
            // Si es mover, no puede haber ficha en destino
            if (!movimiento.EsCaptura && casillaDestino.Tengoficha())
            {
                Console.WriteLine("Casilla seleccionada ya contiene una ficha");
                return;
            }
            //Si es mover o capturar como Torre, Alfil, reina, no puede haber fichas en camino
            //Si es Torre
            if(movimiento.FichaAMover == 'R')
            {
                if(!Tablero.SaberSiHayFichasEnElCaminoParaTorre(casillaOrigen, casillaDestino))
                {
                    Console.WriteLine("Existe una ficha en la dirección indicada");
                    return;
                }
            }
            //Si es Reina

            //Si es Alfil

            // Si es capturar, tiene ficha y es de diferente color, se captura
            if (movimiento.EsCaptura && casillaDestino.Tengoficha() && casillaOrigen.SonLasFichasDelMismoColor(casillaDestino))
            {
                Console.WriteLine("No existe ficha enemiga en la casilla de destino");
                return;
            }

            bool movimientoValido;
            if (movimiento.EsCaptura)
            {
                movimientoValido = casillaOrigen.FichaActual.validarCaptura(casillaOrigen, casillaDestino);
            }
            else
            {
                movimientoValido = casillaOrigen.FichaActual.ValidarMovimiento(casillaOrigen, casillaDestino);
            }

            if(!movimientoValido)
            {
                Console.WriteLine("El movimiento no se puede ejecutar");
                return;
            }

            casillaOrigen.FichaActual.AumentarNumeroMovimientos();
            Tablero.MoverFicha(casillaOrigen.Coordenadas, casillaDestino.Coordenadas);
            RegistrarMovimiento(notacion);
            AlternarJugador();
        }
    }
}
