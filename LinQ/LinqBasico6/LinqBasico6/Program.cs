using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqBasico6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Persona> personas = new List<Persona>()
            {
                new Persona("Roberto", "Lamarca", 1, 180, 26, Genero.Masculino),
                new Persona("Juan", "Justo", 2, 170, 21, Genero.Masculino),
                new Persona("Ana", "Maria", 3, 150, 22, Genero.Femenino),
                new Persona("Fausto", "Sarmiento", 4, 164, 29, Genero.Masculino),
                new Persona("Mari", "Curie", 5, 164, 28, Genero.Femenino),
                new Persona("Eva", "Brown", 6, 160, 43, Genero.Femenino),
                new Persona("Hector", "Larrea", 7, 160, 37, Genero.Masculino),
                new Persona("Sabrina", "Noco", 8, 175, 33, Genero.Femenino),
                new Persona("Vicente", "Carpeta", 9, 182, 21, Genero.Masculino),
                new Persona("Pepa", "Wood", 10, 165, 20, Genero.Femenino),
                new Persona("Lita","Lazzari",  11, 160, 19, Genero.Femenino),
                new Persona("Lara", "Croft", 12, 162, 18, Genero.Femenino),
                new Persona("Juan", "Coqui", 1, 180, 26, Genero.Masculino),
                new Persona("AJuan", "Justo", 2, 170, 21, Genero.Masculino),
                new Persona("Ana", "Saria", 3, 150, 22, Genero.Femenino),
                new Persona("Lole", "Pista", 4, 164, 29, Genero.Masculino),
                new Persona("Nerea", "Panza", 5, 164, 28, Genero.Femenino),
                new Persona("Sali", "Crue", 6, 160, 43, Genero.Femenino),
                new Persona("Pixie", "Rosti", 7, 160, 37, Genero.Masculino),
                new Persona("Sibi", "Nibi", 8, 175, 33, Genero.Femenino),
                new Persona("Vichi", "Dire", 9, 182, 21, Genero.Masculino),
                new Persona("Pesca", "Maggi", 10, 165, 20, Genero.Femenino),
                new Persona("Lola","Mora",  11, 160, 19, Genero.Femenino),
                new Persona("Laura", "Noto", 12, 162, 18, Genero.Femenino)
            };

            //----------------------------------------------
            Separador();
            // 1. porden por Keys

            var ordenPorKey = from p in personas
                               group p by p.Edad into edadGrp
                               orderby edadGrp.Key
                               select edadGrp;

            foreach (var key in ordenPorKey)
            {
                Console.WriteLine($"{key.Key}");
                foreach (var item in key)
                {
                    Console.WriteLine($" {item.Edad}");
                }
            }

            //----------------------------------------------
            Separador();
            // 2. Personalizar Grupos
            int[] arrayDeNumeros = {124, 951, 66, 5, 6, 3, 2, 1, 5, 7, 234, 54, 14, 653, 3, 4, 5, 6, 7, 33, 155, 87, 3, 566 };

            var numeros = from n in arrayDeNumeros
                          orderby n
                          let parImpar = (n % 2 == 0) ? "Par" : "Impar"
                          group n by parImpar into nums
                          orderby nums.Count()
                          select nums;

            foreach (var num in numeros)
            {
                Console.WriteLine($"{num.Key}");
                foreach (var i in num)
                {
                    Console.WriteLine($" {i}");
                }
            }

            //----------------------------------------------

            Separador();
            // 3. Datos de dos grupos, seleccion arbitraria

            var personasVariosGrupos = from p in personas
                                      let ageSelection =
                                            p.Edad < 20                              // Si edad < 20 
                                                ? "Joven"                            // sale por joven
                                                : p.Edad >= 20 && p.Edad <= 32       // en cambio si >=20 y <= 32 
                                                    ? "Adulto"                       // sale por adulto
                                                    : "Senior"                       // o al final..
                                      group p by ageSelection;

            foreach (var p in personasVariosGrupos)
            {
                Console.WriteLine($"{p.Key}");
                foreach (var i in p)
                {
                    Console.WriteLine($" {i.Edad}");
                }
            }

            //----------------------------------------------
            Separador();

            // 4. Obtener el key y la cantidad de cada grupo para todos los grupos
            var cuantosPorCadaGrupo = from p in personas
                                     group p by p.Genero into g
                                     orderby g.Count()
                                     select new { Genero = g.Key, CantidadPersonas = g.Count() };

            foreach (var cantidad in cuantosPorCadaGrupo)
            {
                Console.WriteLine($"{cantidad.Genero}");
                Console.WriteLine($"{cantidad.CantidadPersonas}");
            }
        }

        private static void Separador()
        {
            Console.WriteLine(new string('=', 40));
        }

    }

    internal class Persona
    {
        private string nombre;
        private string apellido;
        private int id;
        private int altura;
        private int edad;

        private Genero genero;

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = value;
            }
        }

        public int ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public int Altura
        {
            get
            {
                return this.altura;
            }
            set
            {
                this.altura = value;
            }
        }

        public int Edad
        {
            get
            {
                return this.edad;
            }
            set
            {
                this.edad = value;
            }
        }

        public Genero Genero
        {
            get
            {
                return this.genero;
            }
            set
            {
                this.genero = value;
            }
        }

        public Persona(string nombre, string apellido, int id, int altura, int edad, Genero genero)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.id = id;
            this.Altura = altura;
            this.Edad = edad;
            this.Genero = genero;
        }
    }

    internal enum Genero
    {
        Masculino,
        Femenino
    }
}
