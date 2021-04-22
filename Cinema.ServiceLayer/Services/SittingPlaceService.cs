using System;
using System.Collections.Generic;
using Cinema.DAL.EF;
using Cinema.DAL.Entities;
using Cinema.Services.DTO;
using Serilog;

namespace Cinema.Services.Services
{
    public class SittingPlaceService
    {
        private Repository<SittingPlaceModel> _repository;

        public SittingPlaceService()
        {
            _repository = new Repository<SittingPlaceModel>();
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
            if (!IsSittingPlaceDTOValid(sittingPlaceModel))
            {
                return false;
            }

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
            if (!IsSittingPlaceDTOValid(sittingPlaceModel))
            {
                return false;
            }

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
            if (!IsSittingPlaceDTOValid(sittingPlaceModel))
            {
                return false;
            }

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

        private bool IsSittingPlaceDTOValid(SittingPlaceModel sittingPlaceModel)
        {
            if (sittingPlaceModel != null && sittingPlaceModel.Number > 0 && sittingPlaceModel.Row > 0)
            {
                return true;
            }

            return false;
        }
    }
}