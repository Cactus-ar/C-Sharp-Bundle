using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesGeneral
{
    public interface IProductoDigital : IProducto
    {
        int CantidadDescargas { get; }
    }
}
