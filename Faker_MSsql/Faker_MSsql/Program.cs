using Bogus;
using System;
using System.Text;


/* faker mssql genera un archivo script para insertar en una db
 * con X cantidad de registros
 */
namespace Faker_MSsql
{
    class Program
    {
        static void Main(string[] args)
        {

            //Algunos Parametros para la generacion del archivo
            int CantidadEntradas = 1000;
            string NombreTabla = "Clientes";



            StringBuilder cadena = new StringBuilder();

            cadena.Append($"IF EXISTS(SELECT 1 FROM sys.tables WHERE object_id = OBJECT_ID('{NombreTabla}'))");
            cadena.AppendLine();
            cadena.Append("BEGIN;");
            cadena.AppendLine();
            cadena.Append($"DROP TABLE [{NombreTabla}];");
            cadena.AppendLine();
            cadena.Append("END;");
            cadena.AppendLine();
            cadena.Append("GO");
            cadena.AppendLine();

            //Crear Campos de la tabla
            cadena.Append($"CREATE TABLE [{NombreTabla}] (");
            cadena.AppendLine();

            cadena.Append("[ClientesID] INTEGER NOT NULL IDENTITY(1, 1),"); //Verificar
            cadena.AppendLine();
            cadena.Append("[nombre] VARCHAR(255) NULL,");       //Estos parametros
            cadena.AppendLine();
            cadena.Append("[apellido] VARCHAR(255) NULL,");     //Y agregar
            cadena.AppendLine();
            cadena.Append("[domicilio] VARCHAR(255) NULL,"); //O quitar
            cadena.AppendLine();
            cadena.Append("[dni] VARCHAR(15) NULL,");
            cadena.AppendLine();
            cadena.Append("[email] VARCHAR(255) NULL,");
            cadena.AppendLine();
            cadena.Append("[telefono] VARCHAR(100) NULL,");
            cadena.AppendLine();
            cadena.Append("PRIMARY KEY([ClientesID])");
            cadena.AppendLine();
            cadena.Append(");");
            cadena.AppendLine();
            cadena.Append("GO");
            cadena.AppendLine();

            for (int i = 0; i < CantidadEntradas; i++)
            {
                var data = new Faker("es_MX");
                cadena.Append("INSERT INTO Clientes([nombre],[apellido],[domicilio],[dni],[email],[telefono]) VALUES(");
                cadena.Append("'" + data.Person.FirstName + "', '");
                cadena.Append(data.Person.LastName + "', '");
                cadena.Append(data.Address.StreetAddress(true) + "', '");
                cadena.Append(data.Random.Number(99999999) + "', '");
                cadena.Append(data.Internet.Email() + "', '");
                cadena.Append(data.Phone.PhoneNumber() + "');");
                cadena.AppendLine();
            }
            


            string ruta = Environment.CurrentDirectory.ToString();
            string pathString = System.IO.Path.Combine(ruta, "Archivos");

            System.IO.Directory.CreateDirectory(pathString);

            string nombreArchivo = "Secuencia-" + DateTime.Now.Ticks  + ".sql";
            pathString = System.IO.Path.Combine(pathString, nombreArchivo);
            Console.WriteLine("El archivo se localiza en:\n {0}\n", pathString);


            //generar y guardar el archivo -> debería ser un async si se va a generar mas de 5k de registros

            using (System.IO.StreamWriter fs = new System.IO.StreamWriter(pathString))
            {
                fs.WriteLine(cadena.ToString());
            }


        }
    }
}
