using Lib.Core.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Data.Contextos
{
    public class ProductoDBcontext : DbContext
    {
        public ProductoDBcontext(DbContextOptions opciones) : base(opciones)
        {

        }

        public DbSet<Producto> productos { get; set; }
    }
}
