using PreUni.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PreUni.OnlineTest.DAL.EntityFramework
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> 
        where TEntity : class, new()
    {
        protected DbContext mDbContext;

        public GenericRepository(DbContext dbContext)
        {
            mDbContext = dbContext;
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return Task.FromResult(mDbContext.Set<TEntity>().AsEnumerable()); 
        }

        public Task<TEntity> GetAsync(int id)
        {
            return Task.FromResult(mDbContext.Set<TEntity>().Find(id));
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> condition)
        {
            return mDbContext.Set<TEntity>().Where(condition).AsQueryable<TEntity>();
        }
        
        public Task InsertAsync(TEntity entity)
        {
            mDbContext.Set<TEntity>().Add(entity);

            var result = mDbContext.SaveChangesAsync();

            return result;
        }

        public Task DeleteAsync(TEntity entity)
        {
            mDbContext.Set<TEntity>().Remove(entity);

            var result = mDbContext.SaveChangesAsync();

            return result;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, object>> expression, object value)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
