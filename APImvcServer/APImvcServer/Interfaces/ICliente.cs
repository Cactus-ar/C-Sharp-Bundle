using APImvcServer.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APImvcServer.Interfaces
{
    public interface ICliente
    {
        ICollection<Cliente> GetlistadoClientes();
        Cliente GetCliente(int Id);

        bool ClienteExiste(int Id);
        bool MailClienteExiste(string mail);

        bool CrearCliente(Cliente cliente);
        bool ActualizarCliente(Cliente cliente);
        bool EliminarCliente(Cliente cliente);
        bool GuardarCliente();

    }
}
