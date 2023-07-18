using PawnMaster.Model;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace PawnMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Jugador jugador = new Jugador();
            Jugador jugadora = new Jugador();
            Partida partida = new(jugador, jugadora);
            partida.CrearPartidaDeAjedrez();
            partida.Tablero.MostrarEstadoDelTablero();

            
           
            string movimientoUsuario;
            do
            {
                movimientoUsuario = Console.ReadLine();

                partida.EjecutarTurno(movimientoUsuario);

                partida.Tablero.MostrarEstadoDelTablero();

            } while (movimientoUsuario != "-1");

        }

    }
}