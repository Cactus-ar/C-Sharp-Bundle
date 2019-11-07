using Ef_Mssql_v3.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace Ef_Mssql_v3.Servicios
{
    class contextoDB : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=Clientes;Trusted_Connection=True;ConnectRetryCount=0",
                    options => options.EnableRetryOnFailure());
        }
    }
}
