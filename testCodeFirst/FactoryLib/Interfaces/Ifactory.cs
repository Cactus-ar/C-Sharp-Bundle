using LibreriaComun.entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FactoryLib.Interfaces
{
    public interface IFactory
    {
        //Criterios para atualizar las tablas
        //IEnumerable<FactoryCriterioActualizacion> ListaCriteriosParaActualizar();
        //FactoryCriterioActualizacion CriterioDeActualizacion(int Id);
        Task<bool> CriterioActualizaExiste(int Id);

        //IEnumerable<FactoryCriterioBusqueda> ListaCriteriosParaBuscar();
        //FactoryCriterioBusqueda CriterioDeBusqueda(int Id);
        //bool CriterioBuscaExiste(int Id);

        //todo 
        //void AgregarCriterio(int IdEvento, FactoryCriterioBusqueda criterioDeBusqueda);
        //void ActualizarCriterio(FactoryCriterioBusqueda criterioDeBusqueda);
        //void EliminarCriterio(FactoryCriterioBusqueda criterioDeBusqueda);
        //bool GuardarOperacion();

        //IEnumerable<FactoryPlantilla> ListaPlantillas();
        //FactoryPlantilla ObtenerPlantilla(int Id);
        //bool PlantillaExiste(int id);
        //todo crud

        Task<IEnumerable<FactoryEvento>> ListaEventos();
        Task <FactoryEvento> ObtenerEvento(int Id);
        Task<bool> EventoExiste(int Id);
        Task<int> CrearEvento(FactoryEvento evento);
        //todocrud
    }
}
