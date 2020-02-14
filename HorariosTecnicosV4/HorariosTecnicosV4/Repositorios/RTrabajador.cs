using HorariosTecnicosV4.Contextos;
using HorariosTecnicosV4.Entidades;
using HorariosTecnicosV4.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorariosTecnicosV4.Repositorios
{
    public class RTrabajador : ITrabajador
    {

        private readonly TrabajadorTarea _trabajadorTarea;

        public RTrabajador(TrabajadorTarea trabajadorTarea)
        {
            _trabajadorTarea = trabajadorTarea ?? throw new ArgumentNullException(nameof (trabajadorTarea));
        }

        public void ActualizarTrabajador(Trabajador trabajador)
        {
            throw new NotImplementedException();
        }

        public void AgregarTrabajador(Trabajador trabajador)
        {
            if (trabajador == null)
                throw new ArgumentNullException(nameof(trabajador));

            _trabajadorTarea.Trabajadores.AddAsync(trabajador);
        }

        public void EliminarTrabajador(Trabajador trabajador)
        {
            if (trabajador == null)
                throw new ArgumentNullException(nameof(trabajador));

            _trabajadorTarea.Trabajadores.Remove(trabajador);
        }

        public bool Guardar()
        {
            return (_trabajadorTarea.SaveChanges() >= 0);
            //el metodo retorna el numero de entidades escritas en la db (no importa la forma)
            //si es = a cero significa que no habia novedades en el dbset
            //si el numero es negativo hubo un error intentando guardar los datos en el servidor
        }

        public IEnumerable<Trabajador> ListarTrabajadores()
        {
            return _trabajadorTarea.Trabajadores.ToList();
        }

        public IEnumerable<Trabajador> ListaTrabajadoresBuscada(IEnumerable<int> trabajadores)
        {
            if (trabajadores == null)
                throw new ArgumentNullException(nameof(trabajadores));

            return _trabajadorTarea.Trabajadores.Where(t => trabajadores.Contains(t.Id))
                    .OrderBy(n => n.Nombre)
                    .ToList();
        }

        public Trabajador Trabajador(int trabajador)
        {
            return _trabajadorTarea.Trabajadores.Where(tr => tr.Id == trabajador).FirstOrDefault();
        }

        public bool TrabajadorExiste(int trabajador)
        {
            return _trabajadorTarea.Trabajadores.Any(t => t.Id == trabajador);
        }
    }
}
