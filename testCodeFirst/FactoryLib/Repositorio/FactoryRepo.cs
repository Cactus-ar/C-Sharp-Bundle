using FactoryLib.Contextos;
using FactoryLib.Interfaces;
using LibreriaComun.entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryLib.Repositorio
{
    public class FactoryRepo : IFactory
    {
        private readonly FactoryDBcontext _contexto;

        public FactoryRepo(FactoryDBcontext factoryDBcontext)
        {
            _contexto = factoryDBcontext ?? throw new ArgumentNullException(nameof(factoryDBcontext));
        }

        public async Task<bool> EventoExiste(int Id)
        {
            if (Id == 0)
                throw new ArgumentNullException(nameof(Id));

            //_contexto.QuerysQueActualizan.Any(qa => qa.Id == Id);
            var busqueda = await _contexto.Eventos.FindAsync(Id);
            if (busqueda != null)
                return true;
            else
                return false;
        }

        public async Task<int> CrearEvento(FactoryEvento evento)
        {
            if (evento == null)
                throw new ArgumentNullException(nameof(evento));

            _contexto.Eventos.Add(evento);
            var respuesta = await _contexto.SaveChangesAsync();
            return respuesta;
        }

        public async Task<FactoryEvento> ObtenerEvento(int Id)
        {
            if (Id == 0)
                throw new ArgumentNullException(nameof(Id));

            var busqueda = await _contexto.Eventos.FindAsync(Id);
            if (busqueda != null)
                return busqueda;
            else
                return null;
        }

        public async Task<IEnumerable<FactoryEvento>> ListaEventos()
        {
            return await _contexto.Eventos.ToListAsync();
        }












        public async Task<bool> CriterioActualizaExiste(int Id)
        {
            if (Id == 0)
                throw new ArgumentNullException(nameof(Id));

            //_contexto.QuerysQueActualizan.Any(qa => qa.Id == Id);
            var busqueda =await _contexto.QuerysQueActualizan.FindAsync(Id);
            if (busqueda != null)
                return true;
            else
                return false;
        }

     
    }
}
