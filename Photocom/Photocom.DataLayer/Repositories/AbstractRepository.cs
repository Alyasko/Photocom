using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Photocom.BusinessLogic.Utils;
using Photocom.Contracts;

namespace Photocom.DataLayer.Repositories
{
    public abstract class AbstractRepository<TEntity, TEntry> : IRepository<TEntity, TEntry> 
        where TEntity : class, new ()
        where TEntry : class, new()
    {
        protected AbstractRepository(DbContext context)
        {
            DbContext = context;
        }

        public virtual void Insert(TEntity entity)
        {
            DbContext.Set<TEntry>().Add(ConvertEntityToEntry(entity));
        }

        public virtual void Update(TEntity entity)
        {
            TEntry entry = ConvertEntityToEntry(entity);
            DbContext.Set<TEntry>().Attach(entry);
            DbContext.Entry(entry).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            DbContext.Set<TEntry>().Remove(ConvertEntityToEntry(entity));
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            var entries = DbContext.Set<TEntry>();
            return ConvertEntitiesFromEntries(entries);
        }

        public virtual IEnumerable<TEntity> FindAll(Func<TEntry, bool> expression)
        {
            var entries = DbContext.Set<TEntry>().Where(expression);
            return ConvertEntitiesFromEntries(entries);
        }

        public virtual TEntity First(Func<TEntry, bool> expression)
        {
            return ConvertEntryToEntity(DbContext.Set<TEntry>().First(expression));
        }

        private TEntry ConvertEntityToEntry(TEntity entity)
        {
            return ReflectionHelper.ConvertClassInstances<TEntry>(
                    ReflectionHelper.GetFullTypeName(entity.GetType()),
                    entity);
        }

        private TEntity ConvertEntryToEntity(TEntry entry)
        {
            return ReflectionHelper.ConvertClassInstances<TEntity>(
                    ReflectionHelper.GetFullTypeName(entry.GetType()),
                    entry);
        }

        private IEnumerable<TEntity> ConvertEntitiesFromEntries(IEnumerable<TEntry> entries)
        {
            return entries.Select(ConvertEntryToEntity).ToList();
        } 

        protected DbContext DbContext { get; set; }
    }
}
