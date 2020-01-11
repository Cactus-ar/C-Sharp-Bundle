using Clientes.Core.Modelos;
using Clientes.Data.Configuracion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clientes.Data
{
    class ClientesDBContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Compra> Compras { get; set; }

        public ClientesDBContext(DbContextOptions<ClientesDBContext> opciones)
            :base (opciones)
        {  }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new ClientesConfig());

            builder
                .ApplyConfiguration(new ComprasConfig());
        }
    }
}
