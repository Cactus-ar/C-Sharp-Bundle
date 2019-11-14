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

        public bool ActualizarCliente(Cliente cliente)
        {
            _contexto.Update(cliente);
            return GuardarCliente();
        }

        public bool ClienteExiste(int Id)
        {
            return _contexto.Clientes.Any(cli => cli.Id == Id);
        }

        public bool CrearCliente(Cliente cliente)
        {
            _contexto.Add(cliente);
            return GuardarCliente();
        }

        public bool EliminarCliente(Cliente cliente)
        {
            _contexto.Remove(cliente);
            return GuardarCliente();
        }

        public Cliente GetCliente(int Id)
        {
            return _contexto.Clientes.Where(cli => cli.Id == Id).FirstOrDefault();
        }

        public ICollection<Cliente> GetlistadoClientes()
        {
            return _contexto.Clientes.OrderBy(cli => cli.Apellido).ToList();
        }

        public bool GuardarCliente()
        {
            var estado = _contexto.SaveChanges();
            return estado >= 0 ? true : false;
        }

        public bool MailClienteExiste(string mail)
        {
            var mailExiste = _contexto.Clientes.Where(
                cli => cli.Mail.Trim().ToUpper() == mail.Trim().ToUpper()).FirstOrDefault();
            return mailExiste != null ? true : false;
        }
    }
}
