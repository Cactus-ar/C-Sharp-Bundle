using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqBasico2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Persona> persona = new List<Persona>()
            {
                new Persona("Ceci", 160, 55, Genero.Femenino),
                new Persona("Gabriel", 180, 70, Genero.Masculino),
                new Persona("Hernan", 170, 88, Genero.Masculino),
                new Persona("Ana", 150, 48, Genero.Femenino),
                new Persona("Tito", 160, 55, Genero.Masculino),
                new Persona("Roberto", 164, 77, Genero.Masculino),
                new Persona("Marcela", 164, 77, Genero.Masculino),
                new Persona("Maria", 160, 55, Genero.Femenino),
                new Persona("Sandra", 160, 55, Genero.Femenino),
                new Persona("Peco", 180, 55, Genero.Femenino)

            };

            //----------------------------------------------
            Separador();
            // 1. Linq ejemplos con objetos.
            var cuatoCaracteres = from p in persona
                                 where (p.Nombre.Length == 4)
                                 select p;

            foreach (var p in cuatoCaracteres)
            {
                Console.WriteLine(p.Nombre);
            }

            //----------------------------------------------
            Separador();
            // 2. Ordenados
            var cuatoCaracteresOrdenada = from p in persona
                                        where (p.Nombre.Length == 5)
                                        orderby p.Peso
                                        select p;

            foreach (var p in cuatoCaracteresOrdenada)
            {
                Console.WriteLine(p.Nombre);
            }

            //----------------------------------------------
            Separador();
            // 3. Extraer propiedades a una nueva coleccion
            var nombresExtraidos = from p in persona
                                 where (p.Nombre.Length == 6)
                                 select p.Nombre;

            foreach (var p in nombresExtraidos)
            {
                Console.WriteLine(p);
            }

            //----------------------------------------------
            Separador();
            // 4. Orden complejo
            var personaSpecialOrder = from p in persona
                                     where (p.Nombre.Length == 4)
                                     orderby p.Nombre, p.Altura
                                     select p;

            foreach (var p in personaSpecialOrder)
            {
                Console.WriteLine($"Nombre: {p.Nombre}, Altura: {p.Altura}");
            }

        }

        private static void Separador()
        {
            Console.WriteLine(new string('-', 40));
        }

    }

    internal class Persona
    {
        private string nombre;
        private int altura;
        private int peso;

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

        public int Peso
        {
            get
            {
                return this.peso;
            }
            set
            {
                this.peso = value;
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

        public Persona(string nombre, int altura, int peso, Genero genero)
        {
            this.Nombre = nombre;
            this.Altura = altura;
            this.Peso = peso;
            this.Genero = genero;
        }
    }

    internal enum Genero
    {
        Masculino,
        Femenino
    }

}
