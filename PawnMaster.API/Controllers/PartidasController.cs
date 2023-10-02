using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PawnMaster.API.Dtos;
using PawnMaster.Model;
using PawnMaster.Persistence.Dtos;
using PawnMaster.Persistence.Repositories;
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

        [HttpPost("partidaNueva")]
        [ProducesResponseType(201, Type = typeof(PartidaDtoAPI))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public PartidaDtoAPI CrearPartida(int IdJugadorBlanco, int IdJugadorNegro)
        {
            //Los jugadores deberían entrar como parámetros de la función
            Jugador JugadorBlancoe = new Jugador { Nombre = "Daniel" };
            Jugador JugadorNegroe = new Jugador { Nombre = "Sergio" };

            Partida partida = new(JugadorBlancoe, JugadorNegroe);
            partida.CrearPartidaDeAjedrez();
            var partidaDtoPersistence = new PartidaDto()
            {
                Date = DateTime.Now,
                JugadorBlanco = JugadorBlancoe,
                JugadorNegro = JugadorNegroe,
                JugadorActual = JugadorBlancoe,
                Tablero = partida.RetornarTablero(),
            };

            //PODEMOS DEVOLVER UN TRUE O EL ID DE LA PARTIDA PARA SABER QUE PARTIDA ESTAMOS JUGANDO
            //ESTE ES EL TRUE
            if (_paRepo.CrearPartida(partidaDtoPersistence, IdJugadorBlanco, IdJugadorNegro))
            {
                _respuestaApi.StatusCode = HttpStatusCode.OK;
                _respuestaApi.IsSuccess = true;
            }


            var PartidaDto = new PartidaDtoAPI()
            {

                Date = partida.Date,
                Identificador = partida.Identificador,
                JugadorBlanco = partida.JugadorBlanco,
                JugadorNegro = partida.JugadorNegro
            };

            //this.PartidaEnJuego = partida;
            //HttpContext.Session.Set<Partida>("PartidaEnJuego", partida);
            //var repositorioPartida = new PartidaRepository();
            //repositorioPartida.Partida = PartidaEnJuego;

            //PartidaEnJuego.MostrarEstadoPartida();
            return PartidaDto;
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
            if(partida.JugadorBlancoId !=  jugadorId && partida.JugadorNegroId != jugadorId)
            {
                //Si no es jugadador
                Console.WriteLine("Jugador no pertenece a esta partida.");
                return;
            }

            //Recogemos de quién es el turno
            var TurnoJugador = PartidaRecuperadaDto.Turno.white;
            var ColorJugador = Color.Blanco;
            if (partida.JugadorBlancoId == jugadorId)
            {
                 TurnoJugador = PartidaRecuperadaDto.Turno.white;
                ColorJugador = Color.Blanco;
            }
            else
            {
                TurnoJugador = PartidaRecuperadaDto.Turno.black;
                ColorJugador = Color.Negro;
            }

            //Si no le toca mover a este jugador
            if(partida.TurnoPartida != TurnoJugador)
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

            //Seleccionamos las casillas que vamos a usar
            var casillaOrigen = partida.Tablero.SeleccionarCasilla(movimiento.CoordenadaInicial.PosicionHorizontal, movimiento.CoordenadaInicial.PosicionVertical);
            var casillaDestino = partida.Tablero.SeleccionarCasilla(movimiento.CoordenadaFinal.PosicionHorizontal, movimiento.CoordenadaFinal.PosicionVertical);

            if (!casillaOrigen.Tengoficha())
            {
                Console.WriteLine("Casilla seleccionada no contiene ninguna ficha");
                return;
            }

            //Si el color de la ficha no coincide con el color del jugador
            if(ColorJugador != casillaOrigen.FichaActual.Color)
            {
                Console.WriteLine("Este jugador no puede mover esta ficha");
                return;
            }

            //Si la ficha no coincide con la del movimiento
            if (char.ToUpper(movimiento.FichaAMover) != char.ToUpper(casillaOrigen.FichaActual.Simbolo))
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
            if (movimiento.FichaAMover == 'R')
            {
                if (!partida.Tablero.SaberSiHayFichasEnElCaminoParaTorre(casillaOrigen, casillaDestino))
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

            if (!movimientoValido)
            {
                Console.WriteLine("El movimiento no se puede ejecutar");
                return;
            }

            partida.Tablero.MoverFicha(casillaOrigen.Coordenadas, casillaDestino.Coordenadas);

            partida.Tablero.MostrarEstadoDelTablero();

            _paRepo.GuardarEstadoPartidaDespuesDeUnMovimiento(casillaOrigen, casillaDestino, partidaInt);

        }

        [HttpGet("{partidaInt:int}", Name = "GetPartida")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetPartida(int partidaInt)
        {
            var partida = _paRepo.RecuperarEstadoPartida(partidaInt);
            partida.Tablero.MostrarEstadoDelTablero();
            return Ok();
            //return Ok(partida); NO SE PUEDE PORQUE NO PUEDE TRANFORMAR EL TABLERO EN UN JSON MIRARLO
        }
    }
}
