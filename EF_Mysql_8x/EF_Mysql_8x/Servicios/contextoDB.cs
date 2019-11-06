using EF_Mysql_8x.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Mysql_8x.Servicios
{
    class contextoDB : DbContext
    {

       public DbSet<Empleado> Empleados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseMySQL("server=localhost;port=3306;user=root;password=password;database=employees");
    }
}
