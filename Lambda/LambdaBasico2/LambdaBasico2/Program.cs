using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaBasico2
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
            // Grupo por genero

            IEnumerable<IGrouping<Genero, Persona>> grpGenero = personas                   
                                                                 .GroupBy(p => p.Genero); 

            foreach (IGrouping<Genero, Persona> item in grpGenero)
            {
                Console.WriteLine("Personas con el Genero: " + item.Key);

                foreach (var p in item)
                {
                    Console.WriteLine($" {p.Apellido}, Genero: {p.Genero}");
                }
            }

            //----------------------------------------------
            Separador();
            // 2. Agrupados segun alguna propiedad

            IEnumerable<IGrouping<int, Persona>> grupoEdad = personas                  
                                                          .Where(p => p.Edad > 20)     
                                                          .GroupBy(p => p.Edad);       

            foreach (IGrouping<int, Persona> item in grupoEdad)
            {
                Console.WriteLine("Personas de Edad: " + item.Key);
                foreach (var p in item)
                {
                    Console.WriteLine($" {p.Apellido}, Age: {p.Edad}");
                }
            }

            //----------------------------------------------
            Separador();
            // 3. Agrupar objetos por alguna propiedad de forma alfabetica

            var alfabetGrp = personas.OrderBy(p => p.Nombre).GroupBy(p => p.Nombre[0]);

            foreach (IGrouping<char, Persona> item in alfabetGrp)
            {
                Console.WriteLine($"{item.Key}:");
                foreach (var p in item)
                {
                    Console.WriteLine($" {p.Nombre}");
                }
            }

            //----------------------------------------------
            Separador();
            // 4. ORden por claves multiples
            var multiGrp = personas.GroupBy(p => new { p.Genero, p.Edad });

            foreach (var item in multiGrp)
            {
                Console.WriteLine($"{item.Key}");

                foreach (Persona i in item)
                {
                    Console.WriteLine($" {i.Nombre}");
                }
            }


            //----------------------------------------------
            Separador();
            // Pares-Impares

            int[] arrayDeNumeros = { 5, 6, 3, 2, 1, 5, 7, 234, 54, 14, 653, 3, 4, 5, 6, 7 };

            var numeros = arrayDeNumeros.OrderBy(n => n)
                                        .GroupBy(n => (n % 2 == 0) ? "Par" : "Impar")
                                        .OrderBy(key => key.Count());

            foreach (var item in numeros)
            {
                foreach (var i in item)
                {
                    Console.WriteLine($"  {i}");
                }
            }


            //----------------------------------------------



        }

        private static void Separador()
        {
            Console.WriteLine(new string('*', 40));
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
