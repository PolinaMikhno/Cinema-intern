using System;
using System.Collections.Generic;

namespace Cinema.DAL.EF
{
    public interface IGenericRepository<T> where T : class
    {
        void Create(T item);
        T FindById(Guid id);
        IEnumerable<T> Get();
        IEnumerable<T> Get(Func<T, bool> predicate);
        void Remove(T item);
        void Update(T item);
    }
}