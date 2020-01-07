using System;
using System.Linq;

// Serie de ejemplos introductorios a Linq y EF


namespace LinqBasico1
{
    class Program
    {
        static void Main(string[] args)
        {
            string parrafo = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
            string[] nombresDeGatos = { "Lucky", "Bella", "Luna", "Oreo", "Simba", "Toby", "Loki", "Oscar" };
            int[] numeros = { 5, 6, 3, 2, 1, 5, 6, 7, 8, 4, 234, 54, 14, 653, 3, 4, 5, 6, 7 };

            //----------------------------------------------
            SeparadorDeLineas();

            // 1. Ejemplo simple
            var simpleLinq = from s in parrafo
                             select s;

            Console.WriteLine(string.Join("", simpleLinq));

            //----------------------------------------------
            SeparadorDeLineas();

            // 2. Ejemplo con Condicion
            var menosDeCinco = from num in numeros
                               where num < 5
                               select num;

            Console.WriteLine(string.Join(", ", menosDeCinco));

            //----------------------------------------------
            SeparadorDeLineas();
            // 3. Multiples Condiciones
            var menosDeCincoyMasDeDiez = from num in numeros
                                                where (num > 5) && (num < 10)
                                                select num;

            Console.WriteLine(string.Join(", ", menosDeCincoyMasDeDiez));

            //----------------------------------------------
            SeparadorDeLineas();

            // 4. Ejemplo de contain
            var gatosConA = from cat in nombresDeGatos
                            where cat.Contains("a")
                            select cat;

            Console.WriteLine(string.Join(", ", gatosConA));

            //----------------------------------------------
            SeparadorDeLineas();
            // 5. Ejemplo con multiples consignas
            var gatosMasEspecificos = from cat in nombresDeGatos
                                   where cat.Contains("a")
                                   where cat.Length > 4
                                   select cat;

            Console.WriteLine(string.Join(", ", gatosMasEspecificos));

            //----------------------------------------------
            SeparadorDeLineas();

            // 6. Ejemplo ordenando
            var numerosOrdenados = from num in numeros
                                 where (num > 5) && (num < 10)
                                 orderby num // Argumento opcional: ascending o descending si no se especifica es ascendente
                                 select num;

            Console.WriteLine(string.Join(", ", numerosOrdenados));

        }

        private static void SeparadorDeLineas()
        {
            Console.WriteLine(new string('-', 40));
        }
    }
}
