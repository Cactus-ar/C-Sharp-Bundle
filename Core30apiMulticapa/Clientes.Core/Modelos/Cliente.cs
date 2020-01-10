using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Clientes.Core.Modelos
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Mombre { get; set; }
        public ICollection<Compra> Compras { get; set; }

        public Cliente()
        {
            Compras = new Collection<Compra>();
        }
    }
}
