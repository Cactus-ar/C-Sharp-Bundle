using EF_Mysql_8x.Servicios;
using System;
using System.Linq;

/* Mysql ingenieria inversa de la Db de ejemplo empleados
 * solo a modo de ejemplo sin entrar mucho en detalle
 */


namespace EF_Mysql_8x
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new contextoDB())
            {

                var empleados = db.Empleados.OrderBy(orden => orden.emp_no).ToList();
                foreach (var item in empleados)
                {
                    Console.WriteLine("Numero:", item.emp_no, "Nombre: ", item.first_name, "Apellido: ", item.last_name);
                }

            }
        }
    }
}