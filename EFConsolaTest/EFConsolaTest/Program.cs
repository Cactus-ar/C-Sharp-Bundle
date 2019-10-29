using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace EFConsolaTest
{
    class Program
    {
        
        

        static async Task Main(string[] args)
        {
            var Lista = new List<Empleado>();

            Console.WriteLine("Hello World!");

            using (var db = new DBContexto())
            {
                Lista = await db.Empleados.ToListAsync();
                    
            }

            foreach (var item in Lista)
            {
                Console.WriteLine(item.emp_no + "Apellido: " + item.last_name);
            }
            
            

        }
    }

    public class DBContexto : DbContext
    {
        public DbSet<Empleado> Empleados { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string ssh_host = "localhost";
            const int ssh_puerto = 2222;
            const int ssh_puente = 3306;
            const string ssh_usuaro = "usuario";
            const string ssh_pwd = "password";
            string myConnectionString;

            myConnectionString = "server=" + ssh_host + ";port=" + ssh_puerto + ";uid=" + ssh_usuaro + ";pwd=" + ssh_pwd + ";database=employees";

            optionsBuilder.UseMySql(myConnectionString);
                
        }

    }

    public class Empleado
    {
        [Key]
        public int emp_no { get; set; }

        public string first_name { get; set; }
        public string last_name { get; set; }

    }

}
