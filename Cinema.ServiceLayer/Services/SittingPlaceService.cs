using System;
using System.Collections.Generic;
using Cinema.DAL.EF;
using Cinema.DAL.Entities;
using Cinema.Services.DTO;
using Serilog;

namespace Cinema.Services.Services
{
    public class SittingPlaceService: IService<SittingPlaceModel>
    {
        private Repository<SittingPlaceModel> _repository;

        public SittingPlaceService(Repository<SittingPlaceModel> repository)
        {
            _repository = repository;
        }

        public IEnumerable<SittingPlaceModel> Get()
        {
            return _repository.Get();
        }

        public IEnumerable<SittingPlaceModel> Get(Func<SittingPlaceModel, bool> predicate)
        {
            return _repository.Get(predicate);
        }

        public bool Create(SittingPlaceModel sittingPlaceModel)
        {
            try
            {
                _repository.Create(sittingPlaceModel);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Remove(SittingPlaceModel sittingPlaceModel)
        {
            try
            {
                _repository.Remove(sittingPlaceModel);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Update(SittingPlaceModel sittingPlaceModel)
        {
            try
            {
                _repository.Update(sittingPlaceModel);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }
    }
}