using FactoryLib.Contextos;
using FactoryLib.Repositorio;
using LibreriaComun.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testCodeFirst
{
    class Program
    {
        //tests


        static async Task Main(string[] args)
        {
            FactoryDBcontext contexto = new FactoryDBcontext();
            FactoryRepo repo = new FactoryRepo(contexto);


            //-------------Eventos---------------------
            //bool existe = await repo.EventoExiste(21);

            //crear evento y criterio al mismo tiempo
            /*
            int respuesta =await repo.CrearEvento(new FactoryEvento
            {
                Nombre = "Crear Evento con await",
                Descripcion = "Descripcion Crear Evento await",
                Prioridad = 66,
                CriterioBusca = new FactoryCriterioBusqueda { 
                    Nombre = "Criterio de Busqueda await",
                    Descripcion = "descripcion criterio 2",
                    CriterioBusqueda = "select * tabla 2;",
                    Reemplazos = "**Apellido**",
                    Sucursales = 2

                }
            });
            */

            //var registro = await repo.ObtenerEvento(21);
            /*
            var lista = await repo.ListaEventos();
            foreach (var item in lista)
            {
                Console.WriteLine(item.Nombre);
            }
            */




            //bool ada = await repo.CriterioActualizaExiste(1);




            
            Console.ReadKey();
        }
    }
}
