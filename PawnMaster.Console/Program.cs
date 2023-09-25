using PawnMaster.Model;

Jugador jugador = new Jugador { Nombre = "Daniel" };
Jugador jugadora = new Jugador { Nombre = "Sergio" };
Partida partida = new(jugador, jugadora);
partida.CrearPartidaDeAjedrez();
partida.MostrarEstadoPartida();



string movimientoUsuario;
do
{
    movimientoUsuario = Console.ReadLine();

    partida.EjecutarTurno(movimientoUsuario);

    partida.MostrarEstadoPartida();

} while (movimientoUsuario != "-1");
