using System;
using System.Collections.Generic;
using Cinema.DAL.EF;
using Cinema.Services.DTO.Sessions;
using Serilog;

namespace Cinema.Services.Services
{
    public class SittingPlaceInfoService: IService<SittingPlaceInfoModel>
    {
        private Repository<SittingPlaceInfoModel> _repository;

        public SittingPlaceInfoService(Repository<SittingPlaceInfoModel> repository)
        {
            _repository = repository;
        }

        public IEnumerable<SittingPlaceInfoModel> Get()
        {
            return _repository.Get();
        }

        public IEnumerable<SittingPlaceInfoModel> Get(Func<SittingPlaceInfoModel, bool> predicate)
        {
            return _repository.Get(predicate);
        }

        public bool Create(SittingPlaceInfoModel sittingPlaceInfoModel)
        {
            try
            {
                _repository.Create(sittingPlaceInfoModel);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Remove(SittingPlaceInfoModel sittingPlaceInfoModel)
        {
            try
            {
                _repository.Remove(sittingPlaceInfoModel);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Update(SittingPlaceInfoModel sittingPlaceInfoModel)
        {
            try
            {
                _repository.Update(sittingPlaceInfoModel);
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