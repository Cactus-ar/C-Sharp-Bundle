using EF_SQlite_1.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_SQlite_1.Servicios
{
    public class conectorDB : DbContext
    {
        public DbSet<Jornada> Jornadas { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        //No es buena practica dejar la cadena de conexion tan expuesta dentro de la clase
        //a fines de simpleficar el ejemplo se muestra de esta forma, pero no en produccion

        protected override void OnConfiguring(DbContextOptionsBuilder opciones)
           => opciones.UseSqlite("Data Source=DbTareas.db");
    }
}
