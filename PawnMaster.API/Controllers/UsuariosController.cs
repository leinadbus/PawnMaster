using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Mapping.ByCode.Impl;
using PawnMaster.API.Dtos;
using PawnMaster.Persistence.Dtos;
using PawnMaster.Persistence.Repositories;
using PawnMaster.Persistence.Repositories.InterfaceRepository;
using System.Net;

namespace PawnMaster.API.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly InterfazUsuarioRepository _usRepo;
        protected RespuestaApi _respuestaApi;

        public UsuariosController(InterfazUsuarioRepository usRepo)
        {
            _usRepo = usRepo;
            this._respuestaApi = new();
        }


        [AllowAnonymous]
        [HttpPost("registro")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public RespuestaApi Registro([FromBody] UsuarioRegistroAPIDto usuarioRegistro)
        {
            bool validarCorreoUsuarioUnico = _usRepo.EsCorreoUnico(usuarioRegistro.Email);
            if (!validarCorreoUsuarioUnico)
            {
                _respuestaApi.StatusCode = HttpStatusCode.BadRequest;
                _respuestaApi.IsSuccess = false;
                _respuestaApi.ErrorMessages.Add("El nombre de usuario ya existe");
                return _respuestaApi;
                 ;
            }

            //Mapeo a Objeto de Persistence
            var usuarioRegistroDto = new UsuarioRegistroDto() 
            {
                CorreoElectronico = usuarioRegistro.Email,
                Nombre = usuarioRegistro.Name,
                Password = usuarioRegistro.Contraseña,
                Role = usuarioRegistro.Role
            };


            var usuario =  _usRepo.Registro(usuarioRegistroDto);

            if (!usuario)
            {
                _respuestaApi.StatusCode = HttpStatusCode.BadRequest;
                _respuestaApi.IsSuccess = false;
                _respuestaApi.ErrorMessages.Add("Error en el registro");
                return _respuestaApi;
            }

            _respuestaApi.StatusCode = HttpStatusCode.OK;
            _respuestaApi.IsSuccess = true;
            return _respuestaApi;
        }
    }
}
