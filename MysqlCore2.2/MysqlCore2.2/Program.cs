using MySql.Data.MySqlClient;
using System;

/*Ok, conector para MysqlServer de bajo nivel, pasos:
 * 
 * Instalar el paquete Nuget: MySql.Data.EntityFrameworkCore
 * 
 * El setup del ejemplo consta de:
 * Una vm (virtualbox) corriendo linux. Ubuntu 16x
 * un servidor mysql (5.7)corriendo de forma estandard y escuchando sobre el 3306
 * ssh server que acepta conexiones en el puerto estandard 22
 * el bridge entre el host y el server sobre el puerto 2222
 * 
 * la tabla de ejemplo de employees https://dev.mysql.com/doc/employee/en/
 */


namespace MysqlCore2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new MySqlConnectionStringBuilder();
            int cantidad_registros = 0;
            //concatenar los parametros para construir el string de conexion

            builder.SshHostName = "127.0.0.1";
            builder.SshUserName = "usuario";
            builder.SshPassword = "password";
            builder.SshPort = 2222;


            builder.UserID = "usuario";
            builder.Password = "password";
            builder.Server = "localhost";
            builder.Port = 3306;
            builder.Database = "employees";

            
            using (var conexion = new MySqlConnection(builder.ConnectionString))
            {
                try
                {
                    Console.WriteLine("Accediendo al servidor...");
                    conexion.Open();

                    // Operaciones con la DB van aqui
                    string query = "SELECT first_name, last_name FROM employees ORDER BY last_name ASC";
                    MySqlCommand ejecutar = new MySqlCommand(query, conexion);
                    MySqlDataReader lector = ejecutar.ExecuteReader();

                    while (lector.Read())
                    {
                        cantidad_registros++;
                        Console.WriteLine(lector[0] + " " + lector[1]);
                    }

                    lector.Close();
                    ejecutar.Dispose();
                    lector.Dispose();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                conexion.Close();
                conexion.Dispose();
                Console.WriteLine();
                Console.WriteLine("Listo...registros: " + cantidad_registros.ToString());
            }

        }
    }
}
