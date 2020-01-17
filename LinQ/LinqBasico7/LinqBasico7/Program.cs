using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqBasico7
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

            // 1. Simple Inner Join, seleccionar propiedades
            var innerJoin = from c in compradores
                            orderby c.Rubro
                            join p in proveedores on c.Rubro equals p.Rubro
                            select new
                            {
                                Prov = p.Nombre,
                                Com = c.Nombre,
                                Rubro = c.Rubro
                            };

            foreach (var item in innerJoin)
            {
                Console.WriteLine($"Rubro: {item.Rubro}, Proveedor: {item.Prov}, Comprador: {item.Rubro}");
            }

            //----------------------------------------------
            
            Separador();
            // 2. join con mas de una key
            var joinCompuesto = from c in compradores
                                join p in proveedores on new { c.Rubro, c.Edad } equals new { p.Rubro, p.Edad }
                                select new
                                {
                                    Proveedor = p,
                                    Comprador = c.Nombre
                                };

            foreach (var item in joinCompuesto)
            {
                Console.WriteLine($"Distrito: {item.Proveedor.Nombre}, Edad: {item.Proveedor.Edad}");
                Console.WriteLine($"  Proveedor: {item.Proveedor.Nombre}");
                Console.WriteLine($"  Comprador: {item.Comprador}");
                Console.WriteLine();
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
