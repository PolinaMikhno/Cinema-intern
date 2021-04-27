using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.DAL.Entities;
using Cinema.Services.DTO;
using Serilog;

namespace Cinema.Services.Services
{
    public interface IService<TModel, TEntity> where TModel: class where TEntity: class
    {

        public Task<IEnumerable<TModel>> GetAsync();
        public Task<IEnumerable<TModel>> GetAsync(Func<TEntity, bool> predicate);
        public Task<TModel> CreateAsync(TModel item);
        public bool RemoveAsync(TModel item);
        public bool UpdateAsync(TModel item);

    }
}