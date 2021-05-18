using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Cinema.Services.Services
{
    public interface IService<TModel, TEntity> where TModel: class where TEntity: class
    {

        public Task<IEnumerable<TModel>> GetAsync();
        public Task<IEnumerable<TModel>> GetAsync(Func<TEntity, bool> predicate);
        public Task<TModel> CreateAsync(TModel item);
        public bool RemoveAsync(TModel item);
        public bool UpdateAsync(TModel item);

        public string UploadedFile(string filePath, IFormFile file);

    }
}