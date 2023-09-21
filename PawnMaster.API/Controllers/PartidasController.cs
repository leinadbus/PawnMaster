using Microsoft.AspNetCore.Mvc;
using PawnMaster.API.Dtos;

namespace PawnMaster.API.Controllers
{
    [Route("api/partidas")]
    [ApiController]
    public class PartidasController : ControllerBase
    {

        protected RespuestaApi _respuestaApi;
    }
}
