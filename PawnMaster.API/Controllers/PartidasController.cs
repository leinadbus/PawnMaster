using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PawnMaster.API.Dtos;
using PawnMaster.Model;
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
        private Partida PartidaEnJuego;
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
        public PartidaDtoAPI CrearPartida()
        {

            Jugador JugadorBlancoe = new Jugador { Nombre = "Daniel" };
            Jugador JugadorNegroe = new Jugador { Nombre = "Sergio" };

            Partida partida = new(JugadorBlancoe, JugadorNegroe);
            partida.CrearPartidaDeAjedrez();



            _respuestaApi.StatusCode = HttpStatusCode.OK;
            _respuestaApi.IsSuccess = true;

            var PartidaDto = new PartidaDtoAPI() {
            
                Date = partida.Date,
                Identificador = partida.Identificador,
                JugadorBlanco = partida.JugadorBlanco,
                JugadorNegro = partida.JugadorNegro
            };

            this.PartidaEnJuego = partida;
            //HttpContext.Session.Set<Partida>("PartidaEnJuego", partida);
            var repositorioPartida = new PartidaRepository();
            repositorioPartida.Partida = PartidaEnJuego;
            PartidaEnJuego.MostrarEstadoPartida();
            return PartidaDto;
        }


    }
}
