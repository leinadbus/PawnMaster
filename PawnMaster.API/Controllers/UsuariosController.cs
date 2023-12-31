﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Mapping.ByCode.Impl;
using PawnMaster.API.Dtos;
using PawnMaster.Model;
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

        [HttpGet("usuarios")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetUsuarios()
        {
            var listaUsuarios = _usRepo.GetJugadores();
            var listaUsuariosDto = new List<JugadoresDtoApi>();
            foreach (var item in listaUsuarios)
            {
                listaUsuariosDto.Add(new JugadoresDtoApi
                {
                    Id = item.Id,
                    Nombre = item.Nombre,
                    Correo = item.Correo,
                    FechaCreacion = item.CreacionCuenta
                });
            }
            return Ok(listaUsuariosDto);
        }

        [HttpGet("usuario/{id}")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetUsuario(int id)
        {
            var Usuario = _usRepo.GetJugador(id);

            if (Usuario == null)
            {
                return NotFound();
            }

            var UsuarioDto = new JugadoresDtoApi
                {
                    Id = Usuario.Id,
                    Nombre = Usuario.Nombre,
                    Correo = Usuario.Correo,
                    FechaCreacion = Usuario.CreacionCuenta
            };
            
            return Ok(UsuarioDto);
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


            var usuario = _usRepo.Registro(usuarioRegistroDto);

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


        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Login([FromBody] UsuarioLoginDto usuarioLoginDto)
        {
            var respuestaLogin = _usRepo.Login(usuarioLoginDto);


            if (respuestaLogin.UserName == null || string.IsNullOrEmpty(respuestaLogin.Token))
            {
                _respuestaApi.StatusCode = HttpStatusCode.BadRequest;
                _respuestaApi.IsSuccess = false;
                _respuestaApi.ErrorMessages.Add("El nombre de usuario o password no son correctos");
                return BadRequest(_respuestaApi);
            }

            _respuestaApi.StatusCode = HttpStatusCode.OK;
            _respuestaApi.IsSuccess = true;
            _respuestaApi.Result = respuestaLogin;
            return Ok(_respuestaApi);
        }

    }
}
