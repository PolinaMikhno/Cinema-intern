using System;
using System.Collections.Generic;
using Cinema.DAL.EF;
using Cinema.Services.DTO.Sessions;
using Serilog;

namespace Cinema.Services.Services
{
    public class AdditionalProductService
    {
        private Repository<AdditionalProductModel> _repository;

        public AdditionalProductService()
        {
            _repository = new Repository<AdditionalProductModel>();
        }

        public IEnumerable<AdditionalProductModel> Get()
        {
            return _repository.Get();
        }

        public IEnumerable<AdditionalProductModel> Get(Func<AdditionalProductModel, bool> predicate)
        {
            return _repository.Get(predicate);
        }

        public bool Create(AdditionalProductModel additionalProductModel)
        {
            if (!IsAdditionalProductDTOValid(additionalProductModel))
            {
                return false;
            }

            try
            {
                _repository.Create(additionalProductModel);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Remove(AdditionalProductModel additionalProductModel)
        {
            if (!IsAdditionalProductDTOValid(additionalProductModel))
            {
                return false;
            }

            try
            {
                _repository.Remove(additionalProductModel);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Update(AdditionalProductModel additionalProductModel)
        {
            
            if (!IsAdditionalProductDTOValid(additionalProductModel))
            {
                return false;
            }

            try
            {
                _repository.Update(additionalProductModel);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }


        private bool IsAdditionalProductDTOValid(AdditionalProductModel additionalProductModel)
        {
            return additionalProductModel.Price > 0;
        }
    }
}