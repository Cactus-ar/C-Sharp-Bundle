using Clientes.Core.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Core.Servicios
{
    public interface IClienteServicio
    {
        Task<IEnumerable<Cliente>> GetAllClientes();
        Task<Cliente> GetClienteById(int id);
        Task<Cliente> CreateCliente(Cliente nuevoCliente);
        Task UpdateCliente(Cliente clienteAactualizar, Cliente cliente);
        Task DeleteCliente(Cliente cliente);
    }
}
