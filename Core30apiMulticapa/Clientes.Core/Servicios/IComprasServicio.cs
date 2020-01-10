using Clientes.Core.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Core.Servicios
{
    public interface IComprasServicio
    {
        Task<IEnumerable<Compra>> GetAllWithCliente();
        Task<Compra> GetCompraId(int id);
        Task<IEnumerable<Compra>> GetComprasByClienteId(int clienteId);
        Task<Compra> CreateCompra(Compra nuevaCompra);
        Task UpdateCompra(Compra compraAactualizar, Compra compra);
        Task DeleteCompra(Compra compra);
    }
}
