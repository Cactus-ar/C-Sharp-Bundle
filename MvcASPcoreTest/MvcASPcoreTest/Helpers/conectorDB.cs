using Microsoft.EntityFrameworkCore;
using MvcASPcoreTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcASPcoreTest.Helpers
{
    public class conectorDB : DbContext
    {
        public conectorDB (DbContextOptions<conectorDB> opciones)
            :base(opciones)
        {

        }

        public DbSet<Cliente> clientes { get; set; }

    }
}
