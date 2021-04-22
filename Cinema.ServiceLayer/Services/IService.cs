using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.Services.DTO;
using Serilog;

namespace Cinema.Services.Services
{
    public interface IService<T> where T: class
    {

        public IEnumerable<T> Get();
        public IEnumerable<T> Get(Func<T, bool> predicate);
        public bool Create(T item);
        public bool Remove(T item);
        public bool Update(T item);

    }
}