using LamLinqDb.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LamLinqDb
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var context = new DbConexion())
            {
                var lista = context.Clientes.ToList();

                foreach (var item in lista)
                {
                    Console.WriteLine(item.Nombre);
                }
            }


        }
    }

}
