using HorariosTecnicosV4.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorariosTecnicosV4.Contextos
{
    public class TrabajadorTarea : DbContext
    {
        public TrabajadorTarea(DbContextOptions<TrabajadorTarea> opciones) :
            base (opciones)
        {

        }

        public DbSet<Trabajador> Trabajadores { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

    }
}
