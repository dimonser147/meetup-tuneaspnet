using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPD.DAL
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected TunePerformanceDemoEntities _dbContext;

        public Repository(TunePerformanceDemoEntities dbContext)
        {
            _dbContext = dbContext;
        }

        protected IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }

        public virtual void Create(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public virtual TEntity GetById(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public virtual void Update(TEntity entity)
        {
            _dbContext.Entry<TEntity>(entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
