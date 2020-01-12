using LamLinqDb.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LamLinqDb.Helpers
{
    public class DbConexion : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TallerMecanico;Trusted_Connection=True;");
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
