using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Photocom.Contracts;

namespace Photocom.DataLayer.Repositories
{
    public abstract class AbstractRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected AbstractRepository(DbContext context)
        {
            DbContext = context;
        }

        public virtual void Insert(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            DbContext.Set<TEntity>().Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbContext.Set<TEntity>().ToList();
        }

        public virtual IEnumerable<TEntity> FindAll(Func<TEntity, bool> expression)
        {
            return DbContext.Set<TEntity>().Where(expression).ToList();
        }

        public virtual TEntity First(Func<TEntity, bool> expression)
        {
            return DbContext.Set<TEntity>().First(expression);
        }

        protected DbContext DbContext { get; set; }
    }
}
