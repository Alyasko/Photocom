using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photocom.Contracts
{
    public interface IRepository<TEntity, TEntry> where TEntity : class where TEntry : class
    {
        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> FindAll(Func<TEntity, bool> expression);

        TEntity First(Func<TEntity, bool> expression);
    }
}
