using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesGeneral
{
    public class ProductoFisico : Producto, IProducto
    {
        
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public bool Enviado { get; private set; }

        public void enviarProducto(Cliente cliente)
        {
            if (!Enviado)
            {
                Console.WriteLine($"Simular Envio de {Descripcion}, a {cliente.Apellido} con Domicilio en {cliente.Domicilio}");
                Enviado = true;
            }

        }
    }
}
