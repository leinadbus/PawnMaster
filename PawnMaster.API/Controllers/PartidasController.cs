using Microsoft.AspNetCore.Mvc;
using PawnMaster.API.Dtos;
using PawnMaster.Persistence.Repositories.InterfaceRepository;

namespace PawnMaster.API.Controllers
{
    [Route("api/partidas")]
    [ApiController]
    public class PartidasController : ControllerBase
    {
        private readonly InterfazPartidaRepository _paRepo;
        protected RespuestaApi _respuestaApi;

        public PartidasController(InterfazPartidaRepository paRepo)
        {
            _paRepo = paRepo;
            _respuestaApi = new();
        }

    }
}
