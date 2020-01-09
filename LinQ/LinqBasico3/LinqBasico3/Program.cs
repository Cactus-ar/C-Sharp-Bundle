using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqBasico3
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
                new Persona("Lara", "Croft", 12, 162, 18, Genero.Femenino)
            };

            //----------------------------------------------
            Separador();
            // 1. Crear objetos anonimos del tipo joven
            var coleccionJoven = from p in personas
                              where p.Edad < 25
                              select new
                              {
                                  Nombre = p.Nombre,
                                  Edad = p.Edad
                              };

            foreach (var p in coleccionJoven)
            {
                Console.WriteLine($"Mi nombre es {p.Nombre} y tengo {p.Edad} años.");
            }

            //----------------------------------------------

            Separador();
            // 2. Igual pero reusando los nombres dela propiedad (menos visible)
            var jovenes_2 = from p in personas
                                      where p.Edad < 25
                                      select new
                                      {
                                          p.Nombre,
                                          p.Edad
                                      };

            foreach (var p in jovenes_2)
            {
                Console.WriteLine($"Nombre {p.Nombre} , Edad {p.Edad}");
            }

            //----------------------------------------------
            Separador();
            // 3. Reusando las propiedades
            var jovenesMix = from p in personas
                                     where p.Edad < 25
                                     select new
                                     {
                                         N = p.Nombre,
                                         p.Edad
                                     };

            foreach (var p in jovenesMix)
            {
                Console.WriteLine($"Nombre {p.N} ,Edad  {p.Edad}.");
            }

            //----------------------------------------------
            Separador();
            // 4. Crear objetos Joven desde Personas
            var objJoven = from p in personas
                                 where p.Edad < 25
                                 select new Joven
                                 {
                                     NombreCompleto = p.Nombre,
                                     Edad = p.Edad
                                 };

            foreach (var p in objJoven)
            {
                Console.WriteLine($"Nombre: {p.NombreCompleto} ,Edad:  {p.Edad}.");
            }

            //----------------------------------------------
            Separador();
            // 5. Crear objetos Joven desde Personas concatenando
            var objJovenConcat = from p in personas
                                      where p.Edad < 25
                                      select new Joven
                                      {
                                          NombreCompleto = string.Format($"{p.Nombre} {p.Apellido}"),
                                          Edad = p.Edad
                                      };
            

            foreach (var p in objJovenConcat)
            {
                Console.WriteLine($"Nombre: {p.NombreCompleto} , Edad: {p.Edad}.");
            }



        }

        private static void Separador()
        {
            Console.WriteLine(new string('=', 40));
        }
    }

    internal class Joven
    {
        public string NombreCompleto { get; set; }
        public int Edad { get; set; }
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
