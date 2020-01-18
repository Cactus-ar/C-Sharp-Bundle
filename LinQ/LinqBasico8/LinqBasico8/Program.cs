using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqBasico8
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Comprador> compradores = new List<Comprador>()
            {
                new Comprador() { Nombre = "Juan", Rubro = "Carne", Edad = 22},
                new Comprador() { Nombre = "Pedro", Rubro = "Verdura", Edad = 40},
                new Comprador() { Nombre = "Pocho", Rubro = "Almacen", Edad = 30 },
                new Comprador() { Nombre = "Maria", Rubro = "Limpieza", Edad = 35 },
                new Comprador() { Nombre = "Lole", Rubro = "Carne", Edad = 40 },
                new Comprador() { Nombre = "Sylvia", Rubro = "Verdura", Edad = 22 },
                new Comprador() { Nombre = "Rebeca", Rubro = "Almacen", Edad = 30 },
                new Comprador() { Nombre = "Jaime", Rubro = "Limpieza", Edad = 35 },
                new Comprador() { Nombre = "Pancho", Rubro = "Carne", Edad = 40 },

                new Comprador() { Nombre = "Rolo", Rubro = "Carne", Edad = 66},
                new Comprador() { Nombre = "Pincha", Rubro = "Verdura", Edad = 67},
                new Comprador() { Nombre = "Pocho", Rubro = "Almacen", Edad = 68 },
                new Comprador() { Nombre = "Xime", Rubro = "Limpieza", Edad = 65 },
                new Comprador() { Nombre = "Marta", Rubro = "Carne", Edad = 43 },
                new Comprador() { Nombre = "Sosa", Rubro = "Verdura", Edad = 52 },
                new Comprador() { Nombre = "Salome", Rubro = "Almacen", Edad = 50 },
                new Comprador() { Nombre = "Porota", Rubro = "Limpieza", Edad = 35 },
                new Comprador() { Nombre = "Pesca", Rubro = "Carne", Edad = 40 }

            };
            List<Proveedor> proveedores = new List<Proveedor>()
            {
                new Proveedor() { Nombre = "Heraclito", Rubro = "Carne", Edad = 22 },
                new Proveedor() { Nombre = "Parmenides", Rubro = "Verdura", Edad = 40 },
                new Proveedor() { Nombre = "Socrates", Rubro = "Almacen", Edad = 35 },
                new Proveedor() { Nombre = "Aristoteles", Rubro = "Limpieza", Edad = 30 }
            };

            //----------------------------------------------
            Separador();

            // 1. Simple group Join, el resultado se aloja en una variable (into..) la cual hay que iterar para obtener los resultados
            var grpJoin = from p in proveedores
                            orderby p.Rubro
                            join c in compradores on p.Rubro equals c.Rubro into grupoCompras
                            select new
                            {
                                p.Nombre,
                                p.Rubro,
                                Compradores = grupoCompras
                            };

            foreach (var item in grpJoin)
            {
                Console.WriteLine($"Rubro: {item.Rubro}, Proveedor: {item.Nombre}" + $"\nCompradores:");

                foreach (var comprador in item.Compradores)
                {
                    Console.WriteLine($" {comprador.Nombre}");
                }
            }

            //----------------------------------------------

            Separador();
            // 2. Realizar alguna operacion sobre la coleccion 
            var opJoin = from p in proveedores
                          orderby p.Rubro
                          join c in compradores on p.Rubro equals c.Rubro into grupoCompras
                          select new
                          {
                              p.Nombre,
                              p.Rubro,
                              Compradores = from b in grupoCompras
                                            orderby b.Nombre
                                            select b
                          };

            foreach (var item in grpJoin)
            {
                Console.WriteLine($"Proveedor: {item.Nombre}, Rubro: {item.Rubro}");

                foreach (var comprador in item.Compradores)
                {
                    Console.WriteLine($"Comprador: {comprador.Nombre}, Rubro: {comprador.Rubro}");
                }
            }


        }

        private static void Separador()
        {
            Console.WriteLine(new string('*', 40));
        }

    }

    internal class Proveedor
    {
        public string Nombre { get; set; }
        public string Rubro { get; set; }
        public int Edad { get; set; }
    }

    internal class Comprador
    {
        public string Nombre { get; set; }
        public string Rubro { get; set; }
        public int Edad { get; set; }
    }
}
