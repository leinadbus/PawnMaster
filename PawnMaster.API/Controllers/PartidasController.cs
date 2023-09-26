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
        public void HacerMovimiento(string notacion)
        {

            //PartidaEnJuego.EjecutarTurno(notacion);
            //PartidaEnJuego.MostrarEstadoPartida();

        }

        [HttpGet("{partidaInt:int}", Name = "GetPartida")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetPartida(int partidaInt)
        {
            var partida = _paRepo.RecuperarEstadoPartida(partidaInt);
            return Ok(partida);
            //return Ok(partida); NO SE PUEDE PORQUE NO PUEDE TRANFORMAR EL TABLERO EN UN JSON MIRARLO
        }
    }
}
