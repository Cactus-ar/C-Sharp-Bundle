using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Core.Repositorio
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        ICliente Clientes { get; }
        ICompra Compras { get; }
        Task<int> CommitAsync();
    }
}
