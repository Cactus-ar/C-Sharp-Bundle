using EF_SQlite_1.Modelos;
using EF_SQlite_1.Servicios;
using System;
using System.Linq;

/* Conexion-creacion de una DB con sqlite
 * requiere el paquete Microsoft.EntityFrameworkCore.Sqlite.Core
 * ademas del Core.tools para la migracion de la DB
 */

namespace EF_SQlite_1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                MenuInicial();
                var tecla = Console.ReadKey();

                switch (tecla.KeyChar)
                {

                    case '1':
                        CrearTarea();
                        break;



                    case 'S':
                    case 's':
                        salir = true;
                        Console.Clear();
                        Console.WriteLine("Adios");
                        break;

                    default:
                        break;
                }


            }

            


        }

        private static void CrearTarea()
        {
            Console.Clear();

            try
            {
                Console.Write("Ingrese el Titulo: ");
                string titulo = Console.ReadLine();
                Console.Write("Descripcion: ");
                string descripcion = Console.ReadLine();


                using (var datos = new conectorDB())
                {
                    datos.Add(new Tarea
                    {
                        Titulo = titulo,
                        Descripcion = descripcion
                    });

                    datos.SaveChanges();
                }

                Console.WriteLine("Datos agregados exitosamente:");
                Console.ReadKey();
                return;

            }
            catch (Exception e)
            {

                Console.WriteLine($"Algo anduvo mal:  {e.Message}");
                Console.WriteLine();
                Console.WriteLine(e.InnerException.ToString());
                Console.ReadKey();
            }


        }

        private static void MenuInicial()
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("   MENU DE DATOS");
            Console.WriteLine("--------------------\n");
            Console.WriteLine("1 .- Alta de Tarea");
            Console.WriteLine("2 .- Consultar Listado");
            Console.WriteLine("3 .- Modificar Tarea");
            Console.WriteLine("4 .- Eliminar");
            Console.WriteLine("S .- Salir del Sistema");
        }
    }


}
