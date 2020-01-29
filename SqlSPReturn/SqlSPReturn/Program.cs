using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Linq;

namespace SqlSPReturn
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var persona = new Clientes();

            Console.WriteLine("Test");

            /*
              	@param1 int,
	            @apellido varchar(200) OUTPUT,
	            @nombre varchar(200) OUTPUT,
	            @email varchar(200) OUTPUT
            */


            var Identada = new SqlParameter("@param1", 12);
            Identada.Direction = ParameterDirection.Input;

            var rtnApellido = new SqlParameter("@apellido", SqlDbType.VarChar);
            rtnApellido.Direction = ParameterDirection.Output;

            var rtnNombre = new SqlParameter("@ReturnCode", SqlDbType.VarChar);
            rtnNombre.Direction = ParameterDirection.Output;

            var rtnEmail = new SqlParameter("@ReturnCode", SqlDbType.VarChar);
            rtnEmail.Direction = ParameterDirection.Output;

            var retornoEstatico = new SqlParameter("@ReturnCode", SqlDbType.Int);
            retornoEstatico.Direction = ParameterDirection.Output;


            using (var db = new contextoDB())
            {
                var resultado = db.persona
                    .FromSqlRaw("EXECUTE dbo.spTraerDatos @param1", Identada)
                    .FirstOrDefaultAsync();

            }


            /*
            foreach (var item in Lista)
            {
                Console.WriteLine($"DNI: {item.dni}, Apellido: {item.apellido}, Email: {item.email}");
            }
            */

        }
    }

    class contextoDB : DbContext
    {
        public DbSet<Clientes> persona { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=Clientes;Trusted_Connection=True;ConnectRetryCount=0",
                    options => options.EnableRetryOnFailure());
        }
    }

    public class Clientes
    {
        [Key]
        public int ClientesID { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string domicilio { get; set; }
        public string dni { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }

    }
}

