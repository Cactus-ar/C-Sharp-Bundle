using System;
using System.Collections.Generic;
using EntidadesGeneral;

namespace UI_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IProducto> carrito = ListaDeCompras();
            Cliente cliente = ObtenerCliente();
            decimal costo = 0;

            foreach (IProducto item in carrito)
            {

                item.enviarProducto(cliente);
                costo += item.Costo;

                if(item is IProductoDigital esDigital)  //c# 7.0+ o no funcionará..no va a crear la variable esDigital 
                {
                    Console.WriteLine($"Descargas Restantes: {esDigital.CantidadDescargas}");
                }

            }

            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Total de Transacciones: ${costo}");
            
        }

        private static Cliente ObtenerCliente()
        {
            return new Cliente
            {
                Id = 1234,
                Apellido = "Ceravolo",
                Nombre = "Gabriel",
                Dni = 12345678,
                Domicilio = "Av. La Serenissima 433",
                Localidad = "Rafael Castillo",
                Cuit = 29121231212,
                Email = "cer@sup.dit",
                Telefono = "555-7896"
            };
        }

        private static List<IProducto> ListaDeCompras()
        {
            List<IProducto> salida = new List<IProducto>();

            salida.Add(new ProductoFisico { Id = 12, Descripcion = "Lapicera 303", Costo = 10.55m });
            salida.Add(new ProductoFisico { Id = 23, Descripcion = "Cartucho 303", Costo = 0.88m });
            salida.Add(new ProductoFisico { Id = 07, Descripcion = "Goma 2 Banderas", Costo = 1.22m });
            salida.Add(new ProductoFisico { Id = 92, Descripcion = "Borratinta Pirata", Costo = 6.24m });
            salida.Add(new ProductoFisico { Id = 44, Descripcion = "Marcadores 12L", Costo = 15.99m });

            //Los digitales siguen implementando Iproducto..como interface base de IproductoDigital
            // y por ello el complilador no se queja

            salida.Add(new ProductoDigital { Id = 12, Descripcion = "Calculadora Windows", Costo = 0 });
            salida.Add(new ProductoDigital { Id = 11, Descripcion = "Descuento de Excel", Costo = -12.33m });
            salida.Add(new ProductoDigital { Id = 124, Descripcion = "Copia de Word", Costo = 25.38m });

            return salida;
        }
    }
}
