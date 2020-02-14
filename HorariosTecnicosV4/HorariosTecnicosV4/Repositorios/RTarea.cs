using HorariosTecnicosV4.Contextos;
using HorariosTecnicosV4.Entidades;
using HorariosTecnicosV4.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorariosTecnicosV4.Repositorios
{
    public class RTarea : ITarea
    {

        private readonly TrabajadorTarea _trabajadorTarea;

        public RTarea(TrabajadorTarea trabajadorTarea)
        {
            _trabajadorTarea = trabajadorTarea ?? throw new ArgumentNullException(nameof(trabajadorTarea));
        }

        public void ActualizarTarea(int tarea)
        {
            throw new NotImplementedException();

        }

        public void AgregarTarea(int trabajador, Tarea tarea)
        {
            if (trabajador == 0)
                throw new ArgumentException(nameof(trabajador));
            if (tarea == null)
                throw new ArgumentNullException(nameof(tarea));

            tarea.TrabajadorID = trabajador;
            _trabajadorTarea.Tareas.AddAsync(tarea); //esto es solamente agregar el dato al dbcontext..el metodo que lo guarda en la DB es Guardar()

        }

        public void EliminarTarea(Tarea tarea)
        {
            if (tarea == null)
                throw new ArgumentNullException(nameof(tarea));

            _trabajadorTarea.Tareas.Remove(tarea);

        }

        public bool Guardar()
        {
            return (_trabajadorTarea.SaveChanges() >= 0);
        }

        public Tarea ObtenerTarea(int trabajador, int tarea)
        {
            return _trabajadorTarea.Tareas.Where(tra => tra.TrabajadorID == trabajador && tra.Id == tarea).FirstOrDefault();
        }

        public IEnumerable<Tarea> ObtenerTareas(int trabajador)
        {
            return _trabajadorTarea.Tareas.Where(ta => ta.TrabajadorID == trabajador)
                    .OrderBy(o => o.Nombre).ToList();
        }

        public bool TareaExiste(int tarea)
        {
            return _trabajadorTarea.Tareas.Any(t => t.Id == tarea);
        }
    }
}
