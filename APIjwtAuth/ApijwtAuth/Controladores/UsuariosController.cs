using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTEST3.Entidades;
using WebApplicationTEST3.Servicios;

namespace WebApplicationTEST3.Controladores
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IServicioUsuario _servicioUsuario;

        public UsuariosController(IServicioUsuario servicioUsuario)
        {
            _servicioUsuario = servicioUsuario;
        }

        [AllowAnonymous]
        [HttpPost("autenticar")]
        public IActionResult Autenticar([FromBody] Usuario paramUsuario)
        {
            var usuario = _servicioUsuario.Autenticar(paramUsuario.NombreUsuario, paramUsuario.Password);
            if (usuario == null)
                return BadRequest(new { mensaje = "Usuario o Contraseña incorrectos." });

            return Ok(usuario);
        }

        [Authorize(Roles = Rol.Admin)]
        [HttpGet]
        public IActionResult Listado()
        {
            var usuarios = _servicioUsuario.Listado();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            var usuario = _servicioUsuario.GetPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }

            //Solo los admin deberian tener acceso a otros registros
            var actualIdDeUsuario = int.Parse(User.Identity.Name);

            if(id != actualIdDeUsuario && !User.IsInRole(Rol.Admin))
            {
                return Forbid();
            }

            return Ok(usuario);
        }

    }
}