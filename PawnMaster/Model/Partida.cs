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
        public Guid identificador { get; set; }

        public DateTime date { get; set; }

        public Tablero Tablero { get; set; }

        public Jugador JugadorBlanco { get; set; }
        public Jugador JugadorNegro { get; set; }

        public List<string> ListaDeMovimientos { get; set; }


        public Partida(Jugador jugadorBlanco, Jugador jugadorNegro)
        {
            identificador = Guid.NewGuid();
            date = DateTime.Now;
            JugadorBlanco = jugadorBlanco;
            JugadorNegro = jugadorNegro;
            Tablero = new Tablero();  
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
            this.Tablero.AñadirFichaAlTablero(0, 0, TorreNegra0);
            this.Tablero.AñadirFichaAlTablero(1, 0, CaballoNegro0);
            this.Tablero.AñadirFichaAlTablero(2, 0, AlfinNegro0);
            this.Tablero.AñadirFichaAlTablero(3, 0, ReinaNegra);
            this.Tablero.AñadirFichaAlTablero(4, 0, ReyNegro);
            this.Tablero.AñadirFichaAlTablero(5, 0, AlfinNegro1);
            this.Tablero.AñadirFichaAlTablero(6, 0, CaballoNegro1);
            this.Tablero.AñadirFichaAlTablero(7, 0, TorreNegra1);

            this.Tablero.AñadirFichaAlTablero(0, 1, PeonNegro0);
            this.Tablero.AñadirFichaAlTablero(1, 1, PeonNegro1);
            this.Tablero.AñadirFichaAlTablero(2, 1, PeonNegro2);
            this.Tablero.AñadirFichaAlTablero(3, 1, PeonNegro3);
            this.Tablero.AñadirFichaAlTablero(4, 1, PeonNegro4);
            this.Tablero.AñadirFichaAlTablero(5, 1, PeonNegro5);
            this.Tablero.AñadirFichaAlTablero(6, 1, PeonNegro6);
            this.Tablero.AñadirFichaAlTablero(7, 1, PeonNegro7);


            //Posicionamiento de las fichas Blancas
            this.Tablero.AñadirFichaAlTablero(0, 7, TorreBlanco0);
            this.Tablero.AñadirFichaAlTablero(1, 7, CaballoBlanco0);
            this.Tablero.AñadirFichaAlTablero(2, 7, AlfinBlanco0);
            this.Tablero.AñadirFichaAlTablero(3, 7, ReinaBlanco);
            this.Tablero.AñadirFichaAlTablero(4, 7, ReyBlanco);
            this.Tablero.AñadirFichaAlTablero(5, 7, AlfinBlanco1);
            this.Tablero.AñadirFichaAlTablero(6, 7, CaballoBlanco1);
            this.Tablero.AñadirFichaAlTablero(7, 7, TorreBlanco1);

            this.Tablero.AñadirFichaAlTablero(0, 6, PeonBlanco0);
            this.Tablero.AñadirFichaAlTablero(1, 6, PeonBlanco1);
            this.Tablero.AñadirFichaAlTablero(2, 6, PeonBlanco2);
            this.Tablero.AñadirFichaAlTablero(3, 6, PeonBlanco3);
            this.Tablero.AñadirFichaAlTablero(4, 6, PeonBlanco4);
            this.Tablero.AñadirFichaAlTablero(5, 6, PeonBlanco5);
            this.Tablero.AñadirFichaAlTablero(6, 6, PeonBlanco6);
            this.Tablero.AñadirFichaAlTablero(7, 6, PeonBlanco7);

        }
    }
}
