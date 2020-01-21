using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaBasico1
{
    class Program
    {
        static void Main()
        {
            string[] gatos = { "Lucky", "Bella", "Michi", "Beto", "Luna", "Oreo", "Simba", "Toby", "Loki", "Oscar" };
            List<int> numeros = new List<int>() { 5, 6, 3, 2, 1, 5, 6, 7, 8, 4, 234, 54, 14, 653, 3, 4, 5, 6, 7 };
            

            Separador();
            // 1. Extraer impares con lambda
            List<int> impares = numeros.Where(n => (n % 2) == 1).ToList();


            Console.WriteLine("Los numeros impares son: " + string.Join(", ", impares));

            //----------------------------------------------------------------------

            Separador();
            // 2. Select vs Where
            List<Guerrero> guerreros = new List<Guerrero>()
            {
                new Guerrero() { Altura = 100 },
                new Guerrero() { Altura = 80 },
                new Guerrero() { Altura = 100 },
                new Guerrero() { Altura = 70 },
            };

            List<int> alturas = guerreros.Where(al => al.Altura == 100)
                                        .Select(al => al.Altura)
                                        .ToList();

            Console.WriteLine("Alturas: " + string.Join(", ", alturas));
            //-----------------------------------------------------------------------------

            Separador();
            // 3. Foreach corto
            Console.WriteLine("Foreach corto para alturas");
            alturas.ForEach(a => Console.WriteLine(a));

            Console.WriteLine("Lo mismo pero dentro de la clase");
            guerreros.ForEach(al => Console.WriteLine(al.Altura)); 
        }

        private static void Separador()
        {
            Console.WriteLine(new string('*', 40));
        }
    }

    internal class Guerrero
    {
        public int Altura { get; set; }
    }
}
