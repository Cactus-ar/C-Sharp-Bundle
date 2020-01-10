using Clientes.Core.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Core.Repositorio
{
    public interface ICliente : IRepositorio<Cliente>
    {
        Task<IEnumerable<Cliente>> GetAllWithComprasAsync();
        Task<Cliente> GetWithComprasByIdAsync(int id);
    }
}
