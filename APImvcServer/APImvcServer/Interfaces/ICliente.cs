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

    }
}
