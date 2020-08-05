using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PreUni.Core.Repository
{
    public interface IGenericRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetAsync(int id);

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> condition);

        Task InsertAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        //Task DeleteAsync(int id);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, object>> expression, object value);

        Task DeleteRange(IEnumerable<TEntity> entities);
    }
}
