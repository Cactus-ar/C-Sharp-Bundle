using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APImvcServer.Dtos;
using APImvcServer.Interfaces;
using APImvcServer.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APImvcServer.Controladores
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

        private ICliente _clientes;

        public ClientesController(ICliente clientes)
        {
            _clientes = clientes;
        }

        [HttpGet("{Id}", Name = "GetCliente")]
        [ProducesResponseType(200, Type = typeof(DtoCliente))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetCliente(int Id)
        {
            if (!_clientes.ClienteExiste(Id))
                return NotFound();

            var cliente = _clientes.GetCliente(Id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var clienteDto = new DtoCliente()
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Mail = cliente.Mail
            };

            return Ok(clienteDto);

        }



        [HttpGet]
        public IActionResult ListadoClientes()
        {
            var clientes = _clientes.GetlistadoClientes();
            var DtoClientes = new List<DtoCliente>();

            foreach (var cliente in clientes)
            {
                DtoClientes.Add(new DtoCliente
                {
                    Id = cliente.Id,
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Mail = cliente.Mail
                    
                });
            }
            return Ok(DtoClientes);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Cliente))]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public IActionResult CrearCliente([FromBody]Cliente cliente)
        {

            if (cliente == null) //si viene mal..return mal
                return BadRequest(ModelState);

            if (cliente.Mail == null) //si viene mal..return mal
                return BadRequest(ModelState);


            //chequear por mail si existe
            var mailExiste = _clientes.MailClienteExiste(cliente.Mail.Trim().ToUpper());
            if (mailExiste)
                return StatusCode(422, "Error mail Invalido");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            
            if(!_clientes.CrearCliente(cliente))
                return StatusCode(500, "Error interno");


            //Si todo fue Ok..crear el cliente
            return CreatedAtRoute("GetCliente", new { Id = cliente.Id }, cliente);
        }


        [HttpPut("{Id}")]
        [ProducesResponseType(201, Type = typeof(Cliente))]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public IActionResult ActualizarCliente(int Id, [FromBody] Cliente cliente)
        {

            if (cliente == null) //si viene mal..return mal
                return BadRequest(ModelState);


            if (cliente.Mail == null) //si viene mal..return mal
                return BadRequest(ModelState);

            //chequear por mail si existe
            var mailExiste = _clientes.MailClienteExiste(cliente.Mail.Trim().ToUpper());

            if (mailExiste)
             //   return StatusCode(422, "Error mail Invalido");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            if (!_clientes.ActualizarCliente(cliente))
                return StatusCode(500, "Error interno");


            //Si todo fue Ok..Actualizar el cliente
            return NoContent();
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult EliminarCliente(int Id)
        {

            //chequear el Id
            if (!_clientes.ClienteExiste(Id))
                return NotFound();

            var registro = _clientes.GetCliente(Id);

            if (!_clientes.EliminarCliente(registro))
                return StatusCode(500, "No se pudo Eliminar");

            return NoContent();

                        
        }

    }
}