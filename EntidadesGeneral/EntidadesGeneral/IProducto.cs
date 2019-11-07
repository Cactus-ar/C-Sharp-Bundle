using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesGeneral
{
    public interface IProducto
    {
        int Id { get; set; }
        string Descripcion { get; set; }
        decimal Costo { get; set; }
        bool Enviado { get;}

        void enviarProducto(Cliente cliente);
    }
}
