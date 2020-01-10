using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Core.Repositorio
{
    public interface IRepositorio<TEntity> where TEntity : class
    {
        ValueTask<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicado);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicado);
        Task AddAsync(TEntity entidad);
        Task AddRangeAsync(IEnumerable<TEntity> entidades);
        void Remove(TEntity entidad);
        void RemoveRange(IEnumerable<TEntity> entidades);
    }
}
