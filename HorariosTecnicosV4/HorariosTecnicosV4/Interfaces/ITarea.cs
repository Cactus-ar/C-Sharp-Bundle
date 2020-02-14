using HorariosTecnicosV4.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorariosTecnicosV4.Servicios
{
    public interface ITarea
    {
        IEnumerable<Tarea> ObtenerTareas(int trabajador);
        Tarea ObtenerTarea(int trabajador, int tarea);
        void AgregarTarea(int trabajador, Tarea tarea);
        void ActualizarTarea(int tarea);
        void EliminarTarea(Tarea tarea);

        bool TareaExiste(int tarea);
        bool Guardar();
    }
}
