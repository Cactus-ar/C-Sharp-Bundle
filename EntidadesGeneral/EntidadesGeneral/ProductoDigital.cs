using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesGeneral
{
    public class ProductoDigital: Producto, IProductoDigital
    {
        
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public bool Enviado { get; private set; }

        public int CantidadDescargas { get; private set; } = 3;

        public void enviarProducto(Cliente cliente)
        {
            if (!Enviado)
            {
                Console.WriteLine($"Simular Envio de {Descripcion}, a {cliente.Apellido} al email {cliente.Email}");
                CantidadDescargas -= 1;
                if (CantidadDescargas < 1)
                {
                    Enviado = true;
                    CantidadDescargas = 0;
                }
                
            }

        }
    }
}
