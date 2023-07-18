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

        public void CrearPartidaDeAjedrez()
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
            this.Tablero.AñadirFichaAlTablero(new Coordenada('C', 7), PeonNegro2);
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


        public void EjecutarTurno(string notacion)
        {
            Movimiento movimiento = new Movimiento();
            if (movimiento.comprobarNotaciónTipoPiezaDada(notacion))
            {
                movimiento.ComprobarSiEsCaptura(notacion);
                if (movimiento.EsCaptura)
                {
                    //Recogemos la notación en el objeto
                    movimiento.RecogerPiezaYCaptura(notacion);
                    //Recogemos del tablero las Casillas para hacer comprobaciones
                    Casilla casillaOrigen = Tablero.SeleccionarCasilla(movimiento.CoordenadaInicial.PosicionHorizontal, movimiento.CoordenadaInicial.PosicionVertical);
                    Casilla casillaDestino = Tablero.SeleccionarCasilla(movimiento.CoordenadaFinal.PosicionHorizontal, movimiento.CoordenadaFinal.PosicionVertical);
                    
                    //Si la casillaDestino tiene una ficha en posesión y NO son del mismo color entonces comprobarmos los movimientos
                    if (casillaDestino.Tengoficha() && !casillaOrigen.SonLasFichasDelMismoColor(casillaDestino))
                    {
                        if (movimiento.FichaAMover == 'P')
                        {
                            if (casillaOrigen.FichaActual.validarCaptura(casillaOrigen, casillaDestino))
                            {
                                //Deberíamos poner el movimiento en la lista de movimientos y la ficha comida en una lista de fichas comidas
                               
                                    casillaOrigen.FichaActual.AumentarNumeroMovimientos();
                                    casillaDestino.SetFichaActual(casillaOrigen.FichaActual);
                                    casillaOrigen.EliminarFicha();
                            }
                            else
                            {
                                Console.WriteLine("El movimiento no se puede ejecutar");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No existe ficha enemiga en la casilla de destino");
                    }

                }
                else
                {
                    //Recogemos la notación en el objeto
                    movimiento.RecogerPiezaYMovimiento(notacion);
                    //Recogemos del tablero las Casillas para hacer comprobaciones
                    Casilla casillaOrigen = Tablero.SeleccionarCasilla(movimiento.CoordenadaInicial.PosicionHorizontal, movimiento.CoordenadaInicial.PosicionVertical);
                    Casilla casillaDestino = Tablero.SeleccionarCasilla(movimiento.CoordenadaFinal.PosicionHorizontal, movimiento.CoordenadaFinal.PosicionVertical);
                    if (casillaOrigen.FichaActual != null)
                    {
                        if (movimiento.FichaAMover == 'P')
                        {
                            if (casillaOrigen.FichaActual.ValidarMovimiento(casillaOrigen, casillaDestino))
                            {
                                Console.WriteLine(casillaOrigen.FichaActual.NumeroMovimientos);
                                casillaOrigen.FichaActual.AumentarNumeroMovimientos();
                                Console.WriteLine(casillaOrigen.FichaActual.NumeroMovimientos);
                                casillaDestino.SetFichaActual(casillaOrigen.FichaActual);
                                casillaOrigen.EliminarFicha();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Casilla seleccionada no contiene ninguna ficha");
                    }
                   
                }

            }
            else
            {
                Console.WriteLine("Notación de movimiento incorrecta.");
            }
        }
    }
}
