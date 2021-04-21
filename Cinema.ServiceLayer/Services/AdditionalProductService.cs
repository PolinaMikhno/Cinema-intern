using System;
using System.Collections.Generic;
using Cinema.DAL.EF;
using Cinema.Services.DTO.Sessions;
using Serilog;

namespace Cinema.Services.Services
{
    public class AdditionalProductService
    {
        private Repository<AdditionalProductDTO> _repository;

        public AdditionalProductService()
        {
            _repository = new Repository<AdditionalProductDTO>();
        }

        public IEnumerable<AdditionalProductDTO> Get()
        {
            return _repository.Get();
        }

        public IEnumerable<AdditionalProductDTO> Get(Func<AdditionalProductDTO, bool> predicate)
        {
            return _repository.Get(predicate);
        }

        public bool Create(AdditionalProductDTO additionalProductDto)
        {
            if (!IsAdditionalProductDTOValid(additionalProductDto))
            {
                return false;
            }

            try
            {
                _repository.Create(additionalProductDto);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Remove(AdditionalProductDTO additionalProductDto)
        {
            if (!IsAdditionalProductDTOValid(additionalProductDto))
            {
                return false;
            }

            try
            {
                _repository.Remove(additionalProductDto);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Update(AdditionalProductDTO additionalProductDto)
        {
            if (!IsAdditionalProductDTOValid(additionalProductDto))
            {
                return false;
            }

            try
            {
                _repository.Update(additionalProductDto);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }


        private bool IsAdditionalProductDTOValid(AdditionalProductDTO additionalProductDto)
        {
            return additionalProductDto.Price > 0;
        }
    }
}