using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DAL.EF
{
    public class Repository<T> : IRepository<T> where T: class
    {
        private DbContext _context;
        private DbSet<T> _dbSet;


        public Repository()
        {
            _context = new DatabaseContext();
            _dbSet = _context.Set<T>();
        }
        
        public void Create(T item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public T FindById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public void Remove(T item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}