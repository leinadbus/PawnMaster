using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PawnMaster.API.Dtos;
using PawnMaster.Model;
using PawnMaster.Persistence.Dtos;
using PawnMaster.Persistence.Repositories.InterfaceRepository;
using System.Net;

namespace PawnMaster.API.Controllers
{
    [Route("api/partidas")]
    [ApiController]
    public class PartidasController : ControllerBase
    {
        private readonly InterfazPartidaRepository _paRepo;
        protected RespuestaApi _respuestaApi;
        //private Partida PartidaEnJuego;
        public PartidasController(InterfazPartidaRepository paRepo)
        {
            _paRepo = paRepo;
            _respuestaApi = new();
        }

        [HttpGet("usuario/{IdJugador}")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult GetPartidasJugando(int IdJugador)
        {
            var ListaPartidas = _paRepo.GetPartidasJugadas(IdJugador);
            var PartidasDtos = new List<PartidasRecuperadasDtoAPI>();
            foreach (var item in ListaPartidas)
            {
                PartidasDtos.Add(new PartidasRecuperadasDtoAPI()
                {
                    Id = item.Id,
                    Date = item.FechaCreaciónPartida,
                    JugadorActual = item.TurnoPartida,
                    JugadorBlanco = item.JugadorBlancoId,
                    JugadorNegro = item.JugadorNegroId.
                    EnJuego = item.PartidaEnJuego

                });
            }
            return Ok(PartidasDtos);
        }


            [HttpPost("partidaNueva")]
        [ProducesResponseType(201, Type = typeof(PartidaDtoAPI))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CrearPartida(int IdJugadorBlanco, int IdJugadorNegro)
        {
            //Los jugadores deberían entrar como parámetros de la función
            Jugador JugadorBlancoe = new Jugador { Nombre = "Ejemplo" };
            Jugador JugadorNegroe = new Jugador { Nombre = "Ejemplo" };

            Partida partida = new(JugadorBlancoe, JugadorNegroe);
            partida.CrearPartidaDeAjedrez();

            //Crear una lista de fichas 
            var Tablero = partida.RetornarTablero();

            List<FichaDto> FichasDto =
            Tablero.TableroJuego
                .Where(p => p.Value.FichaActual != null) // Filtra casillas con fichas
                .Select(f => new FichaDto
                {
                    PosicionVertical = f.Key.PosicionVertical,
                    PosicionHorizontal = f.Key.PosicionHorizontal,
                    Simbolo = f.Value.FichaActual.Simbolo,
                    LetraRepresentante = f.Value.FichaActual.Color.LetraRepresentante
                })
                .ToList();
            var PartidaADataBase = new Persistence.Dtos.PartidaDataDto()
            {
                Date = DateTime.Now,
                EnJuego = true,
                JugadorBlancoId = IdJugadorBlanco,
                JugadorNegroId = IdJugadorNegro,
                JugadorActual = Color.Blanco.LetraRepresentante,
                ListaDeFichas = FichasDto
            };

            var id = _paRepo.CrearPartida(PartidaADataBase);

            PartidaADataBase.Id = id;

            return Ok(PartidaADataBase);
        }

        [HttpPost("movimiento")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public void HacerMovimiento(string notacion, int partidaInt, int jugadorId)
        {
            //Recuperamos la partida 
            var partida = _paRepo.RecuperarEstadoPartida(partidaInt);

            //comprobamos si el jugador está en la partida
            if (partida.JugadorBlancoId != jugadorId && partida.JugadorNegroId != jugadorId)
            {
                //Si no es jugadador
                Console.WriteLine("Jugador no pertenece a esta partida.");
                return;
            }

            //Recogemos de quién es el turno
            var TurnoJugador = Color.Blanco;
            
            //Es el jugador que manda el movimiento el jugador blanco???
            if (partida.JugadorBlancoId == jugadorId)
            {
                TurnoJugador = Color.Blanco;
            }
            else
            {
                TurnoJugador = Color.Negro;
            }

            //Si no le toca mover a este jugador
            if (partida.TurnoPartida != TurnoJugador.LetraRepresentante)
            {
                Console.WriteLine("No es turno del jugador.");
                return;
            }

            if (!Movimiento.ComprobarNotacionMovimientoEsValida(notacion))
            {
                // Si no es válido
                Console.WriteLine("Notación de movimiento incorrecta.");
                return;
            }

            //Recogemos el movimiento
            var movimiento = new Movimiento(notacion);

            //Creamos objeto Jugador de ejemplo
            var JugadorEjemplo = new Jugador();

            //Creamos una partida para poder usar sus métodos
            var PartidaEjemplo = new Partida(JugadorEjemplo, JugadorEjemplo);

            //Ponemos el Tablero que nos interesa en la partida
            PartidaEjemplo.SustituirTablero(partida.Tablero);

            //Comprobamos los movimientos del Tablero
            if (!PartidaEjemplo.ComprobacionesDeMovimiento(movimiento))
            {
                return;
            }
            var TableroEjemplo = PartidaEjemplo.RetornarTablero();
            TableroEjemplo.MostrarEstadoDelTablero();
            //Seleccionamos las casillas que vamos a usar
            var casillaOrigen = TableroEjemplo.SeleccionarCasilla(movimiento.CoordenadaInicial.PosicionHorizontal, movimiento.CoordenadaInicial.PosicionVertical);
            var casillaDestino = TableroEjemplo.SeleccionarCasilla(movimiento.CoordenadaFinal.PosicionHorizontal, movimiento.CoordenadaFinal.PosicionVertical);

            //Si el color de la ficha no coincide con el color del jugador
            if (TurnoJugador != casillaOrigen.FichaActual.Color)
            {
                Console.WriteLine("Este jugador no puede mover esta ficha");
                return;
            }

            _paRepo.GuardarEstadoPartidaDespuesDeUnMovimiento(casillaOrigen, casillaDestino, partidaInt);

            GetPartida(partidaInt);
            //--------------------------------------------------------------------------------- ---------------------------------------------

        }

        [HttpGet("{partidaInt:int}", Name = "GetPartida")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult GetPartida(int partidaInt)
        {
            var partida = _paRepo.RecuperarEstadoPartida(partidaInt);

            //PARA REPRESENTACIÓN GRÁFICA EN CONSOLA ---------------------------------------------------------------------------------------------->
            Console.WriteLine();
            Console.WriteLine("Cementerio de fichas");
            foreach (var f in partida.ListaFichasFueraJuego)
            {
                Console.ForegroundColor = f.ColorFicha == Color.Blanco.LetraRepresentante ? ConsoleColor.Cyan : ConsoleColor.Magenta;
                Console.Write(f.CaracterFicha);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" , ");

            }
            Console.WriteLine();
            partida.Tablero.MostrarEstadoDelTablero();

            //REPRESENTACIÓN GRÁFICA EN CONSOLA ---------------------------------------------------------------------------------------------->

            List<FichasDtoApi> ListaFichasDtoEnJuego = new();
            List<FichasDtoApi> ListaFichasDtoFueraDeJuego = new();

            foreach (var p in partida.ListaFichasEnJuego)
            {
                ListaFichasDtoEnJuego.Add(new FichasDtoApi
                {
                    EnJuego = true,
                    LetracolorRepresentante = p.ColorFicha,
                    PosicionHorizontal = (char)p.PosiciónHorizontal,
                    PosicionVertical = (char)p.PosiciónVertical,
                    Simbolo = p.CaracterFicha

                });
            }

            foreach (var p in partida.ListaFichasFueraJuego)
            {
                ListaFichasDtoFueraDeJuego.Add(new FichasDtoApi
                {
                    EnJuego = false,
                    LetracolorRepresentante = p.ColorFicha,
                    PosicionHorizontal = (char)p.PosiciónHorizontal,
                    PosicionVertical = (char)p.PosiciónVertical,
                    Simbolo = p.CaracterFicha

                });
            }

            var respuesta = new
            {
                Turno = partida.TurnoPartida,
                Tiempo = partida.Date,
                ListaFichasEnJuego = ListaFichasDtoEnJuego,
                ListaFichasFueraDeJuego = ListaFichasDtoFueraDeJuego

            };
            return Ok(respuesta);

        }

    }
}
