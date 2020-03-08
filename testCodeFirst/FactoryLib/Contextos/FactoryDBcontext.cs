using LibreriaComun.entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryLib.Contextos
{
    public class FactoryDBcontext : DbContext
    {

        public DbSet<FactoryPlantilla> Plantillas { get; set; }
        public DbSet<FactoryCriterioBusqueda> QuerysDeBusqueda { get; set; }
        public DbSet<FactoryCriterioActualizacion> QuerysQueActualizan { get; set; }
        public DbSet<FactoryEvento> Eventos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = AUXILIAR; Trusted_Connection = True; MultipleActiveResultSets = true",
                
                    options => options.EnableRetryOnFailure());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
