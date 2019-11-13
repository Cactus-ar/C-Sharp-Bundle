using APImvcServer.Interfaces;
using APImvcServer.Modelos;
using APImvcServer.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APImvcServer.Repositorios
{
    public class RCliente : ICliente
    {

        private ContextoClientesDB _contexto;

        public RCliente(ContextoClientesDB contexto)
        {
            _contexto = contexto;
        }


        public Cliente GetCliente(int Id)
        {
            return _contexto.Clientes.Where(cli => cli.Id == Id).FirstOrDefault();
        }

        public ICollection<Cliente> GetlistadoClientes()
        {
            
            return _contexto.Clientes.OrderBy(cli => cli.Apellido).ToList();
        }
    }
}
