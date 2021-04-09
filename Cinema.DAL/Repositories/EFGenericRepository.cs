using System;
using System.Collections.Generic;

namespace Cinema.DAL.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity: class
    {
        void Create(TEntity entity);
        TEntity Find(long id);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        void Remove(long id);
        void Update(TEntity entity);
    }
}