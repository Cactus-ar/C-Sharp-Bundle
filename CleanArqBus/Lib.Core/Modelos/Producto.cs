using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Core.Modelos
{
    public class Producto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string ImagenUrl { get; set; }
    }
}
