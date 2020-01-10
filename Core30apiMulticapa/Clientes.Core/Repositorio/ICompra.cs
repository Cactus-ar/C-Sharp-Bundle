using Clientes.Core.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Core.Repositorio
{
    public interface ICompra: IRepositorio<Compra>
    {
        Task<IEnumerable<Compra>> GetAllWithArtistAsync();
        Task<Compra> GetWithClienteByIdAsync(int id);
        Task<IEnumerable<Compra>> GetAllWithClienteByClienteIdAsync(int artistId);
    }
    
}
