using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Cinema.DAL.EF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace Cinema.Services.Services
{
    public class Service<TModel, TEntity> : IService<TModel, TEntity> where TModel : class where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;
        private IWebHostEnvironment _environment;

        public Service(IRepository<TEntity> repository, IMapper mapper, IWebHostEnvironment environment)
        {
            _repository = repository;
            _mapper = mapper;
            _environment = environment;
        }

        public async Task<IEnumerable<TModel>> GetAsync()
        {
            IEnumerable<TEntity> entities = await _repository.GetAsync();
            return _mapper.Map<IEnumerable<TModel>>(entities);
        }

        public async Task<IEnumerable<TModel>> GetAsync(Func<TEntity, bool> predicate)
        {
            IEnumerable<TEntity> entity = await _repository.GetAsync(predicate);
            return _mapper.Map<IEnumerable<TModel>>(entity);
        }

        public async Task<TModel> CreateAsync(TModel tModel)
        {
            TEntity dbEntity;
            try
            {
                TEntity tEntity = _mapper.Map<TEntity>(tModel);
                await _repository.CreateAsync(tEntity);
                dbEntity = await _repository.FindAsync(tEntity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Log.Error(e.Message);
                return null;
            }

            return _mapper.Map<TModel>(dbEntity);
        }

        public bool RemoveAsync(TModel tModel)
        {
            try
            {
                TEntity tEntity =
                    _mapper.Map<TEntity>(tModel);

                _repository.RemoveAsync(tEntity);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool UpdateAsync(TModel tModel)
        {
            try
            {
                TEntity tEntity = _mapper.Map<TEntity>(tModel);
                _repository.UpdateAsync(tEntity);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public string UploadedFile(string filePath, IFormFile file)
        {
            string extension = ".jpg";
            if (file == null)
            {
                return null;
            }
            
            string uploadsFolder = Path.Combine(_environment.WebRootPath, filePath);
            string uniqueFileName = Guid.NewGuid() + extension;
            string path = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return uniqueFileName;
        }
    }
}