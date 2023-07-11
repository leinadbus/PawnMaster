using PawnMaster.Model;
using System.Security.Cryptography.X509Certificates;

namespace PawnMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Pepe = new Jugador();            
            var Meme = new Jugador();

            var Partida = new Partida(Pepe ,Meme);
          

            Partida.CrearPartidaDeAjedrez();
         

            Partida.Tablero.MostrarEstadoDelTablero();

            Console.WriteLine("Que ficha quiere mover?");
            char filaInicio = char.Parse(Console.ReadLine());
            int columnaInicio = int.Parse(Console.ReadLine());

            var casillaInicioEjemplo = Partida.Tablero.SeleccionarCasilla(filaInicio, columnaInicio);
            Console.WriteLine(casillaInicioEjemplo.FichaActual.Simbolo);


            Console.WriteLine("A donde la quieres mover?");
            char filafinal = char.Parse(Console.ReadLine());
            int ColumnaFinal = int.Parse(Console.ReadLine());


            var casillaFinalEjemplo = Partida.Tablero.SeleccionarCasilla(filafinal, ColumnaFinal);

            //Console.WriteLine(casillaInicioEjemplo.FichaActual.ValidarDireccion(casillaInicioEjemplo, casillaFinalEjemplo));
            //Console.WriteLine(casillaInicioEjemplo.FichaActual.ValidarPosicion(casillaInicioEjemplo, casillaFinalEjemplo));

            if(casillaInicioEjemplo.FichaActual.ValidarDireccion(casillaInicioEjemplo, casillaFinalEjemplo) && casillaInicioEjemplo.FichaActual.ValidarPosicion(casillaInicioEjemplo, casillaFinalEjemplo))
            {
                
                var ficha = casillaInicioEjemplo.FichaActual;
                ficha.AumentarNumeroMovimientos();
               
                casillaInicioEjemplo.EliminarFicha();
                casillaFinalEjemplo.SetFichaActual(ficha);

                Console.WriteLine();
                Partida.Tablero.MostrarEstadoDelTablero();
            }
            else
            {
                Console.WriteLine("No se Puede realizar ese movimiento");
            }

            Console.WriteLine("Que ficha quiere mover?");
             filaInicio = char.Parse(Console.ReadLine());
             columnaInicio = int.Parse(Console.ReadLine());

             casillaInicioEjemplo = Partida.Tablero.SeleccionarCasilla(filaInicio, columnaInicio);
            Console.WriteLine(casillaInicioEjemplo.FichaActual.Simbolo);


            Console.WriteLine("A donde la quieres mover?");
             filafinal = char.Parse(Console.ReadLine());
             ColumnaFinal = int.Parse(Console.ReadLine());
             casillaFinalEjemplo = Partida.Tablero.SeleccionarCasilla(filafinal, ColumnaFinal);


            if (casillaInicioEjemplo.FichaActual.ValidarDireccion(casillaInicioEjemplo, casillaFinalEjemplo) && casillaInicioEjemplo.FichaActual.ValidarPosicion(casillaInicioEjemplo, casillaFinalEjemplo))
            {
               
                var ficha = casillaInicioEjemplo.FichaActual;
                ficha.AumentarNumeroMovimientos();
               
                casillaInicioEjemplo.EliminarFicha();
                casillaFinalEjemplo.SetFichaActual(ficha);

                Console.WriteLine();
                Partida.Tablero.MostrarEstadoDelTablero();
            }
            else
            {
                Console.WriteLine("No se Puede realizar ese movimiento");
            }

            var casillaPrueba = Partida.Tablero.SeleccionarCasilla('B', 2);
            Console.WriteLine(Partida.existeFichaEnCasillaDestino(casillaPrueba));

        }
    }
    
}