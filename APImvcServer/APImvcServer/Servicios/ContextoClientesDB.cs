using APImvcServer.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APImvcServer.Servicios
{
    public class ContextoClientesDB : DbContext
    {
        public ContextoClientesDB(DbContextOptions<ContextoClientesDB> opciones)
            :base (opciones)
        {

        }

        public DbSet<Cliente>Clientes { get; set; }

    }
}
