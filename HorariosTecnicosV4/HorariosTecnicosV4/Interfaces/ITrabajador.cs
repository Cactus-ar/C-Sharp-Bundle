using HorariosTecnicosV4.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorariosTecnicosV4.Servicios
{
    public interface ITrabajador
    {
        IEnumerable<Trabajador> ListarTrabajadores();
        Trabajador Trabajador(int trabajador);
        IEnumerable<Trabajador> ListaTrabajadoresBuscada(IEnumerable<int> trabajadores); //Lista de trabajadores que cumplen el criterio de busqueda
        void AgregarTrabajador(Trabajador trabajador);
        void ActualizarTrabajador(Trabajador trabajador);
        void EliminarTrabajador(Trabajador trabajador);

        bool TrabajadorExiste(int trabajador);
        bool Guardar();

    }
}
