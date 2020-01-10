using System;
using System.Collections.Generic;
using System.Text;

namespace Clientes.Core.Modelos
{
    public class Compra
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
