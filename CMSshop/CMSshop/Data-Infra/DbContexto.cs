using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSshop.Data_Infra
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> opciones)
            :base (opciones)
        {

        }
    }
}
