using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DAL.EF
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;


        public Repository(CinemaContext cinemaContext)
        {
            _context = cinemaContext;
            _dbSet = _context.Set<T>();
        }

        public Repository()
        {
            _context = new CinemaContext();
        }

        public async Task<T> CreateAsync(T item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
            IEnumerable<T> dbItemEnumerable = await GetAsync(x => x.Equals(item));
            return dbItemEnumerable.FirstOrDefault();
        }

        public async Task<T> FindByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> FindAsync(T item)
        {
            return await _dbSet.FindAsync(item);
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await Task.Run(() => _dbSet.AsNoTracking().ToList());
        }

        public async Task<IEnumerable<T>> GetAsync(Func<T, bool> predicate)
        {
            return await Task.Run(() => _dbSet.Where(predicate));
        }

        public async void RemoveAsync(T item)
        {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async void UpdateAsync(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}