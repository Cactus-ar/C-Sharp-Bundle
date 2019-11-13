using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APImvcServer.Interfaces;
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

        [HttpGet]
        public IActionResult ListadoClientes()
        {
            var clientes = _clientes.GetlistadoClientes().ToList();
            return Ok(clientes);
        }

    }
}