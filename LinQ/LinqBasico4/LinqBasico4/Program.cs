using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqBasico4
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
            // 1. Extraer personas que comienzan con la letra a
            var personasConA = from p in personas
                               let personasLetraA = p.Nombre.ToLower()[0]
                               where personasLetraA == 'a'
                               select p;

            foreach (var p in personasConA)
            {
                Console.WriteLine($"Mi nombre es {p.Nombre} y tengo {p.Edad} años.");
            }

            //----------------------------------------------

            Separador();
            // 2. Extraer nuevos objetos de las personas que comienzan con a
            var jovenesConA = from p in personas
                               let personasLetraA = p.Nombre.ToLower()[0]
                               where personasLetraA == 'a'
                               select new 
                                {
                                    p.Nombre,
                                    p.Edad
                                };

            foreach (var p in jovenesConA)
            {
                Console.WriteLine($"Nombre {p.Nombre} , Edad {p.Edad}");
            }

            //----------------------------------------------
            Separador();
            // 3. Coleccion de Coleccion solo en una simple

            List<List<int>> lista = new List<List<int>>
            {
                new List<int>() { 1, 2, 3 },
                new List<int>() { 4, 5, 6 },
                new List<int>() { 7, 8, 9 }
            };

            var todosLosNumeros = from l in lista
                             let numberos = l
                             from n in numberos
                             select n;

            foreach (var n in todosLosNumeros)
            {
                Console.WriteLine($"{n}");
            }


            //----------------------------------------------
            Separador();
            // 4. Un poco mas complejo donde extraemos las personas que su edad esta por debajo del promedio
            var edadDebajoPromedio = from p in personas
                               let debajo = personas.Sum(personas => personas.Edad) / personas.Count
                               where p.Edad < debajo
                               select p;

            foreach (var p in edadDebajoPromedio)
            {
                Console.WriteLine($"Mi nombre es {p.Nombre} y tengo {p.Edad} años.");
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
