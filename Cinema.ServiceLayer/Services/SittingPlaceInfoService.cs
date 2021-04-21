using System;
using System.Collections.Generic;
using Cinema.DAL.EF;
using Cinema.Services.DTO.Sessions;
using Serilog;

namespace Cinema.Services.Services
{
    public class SittingPlaceInfoService
    {
        private Repository<SittingPlaceInfoDTO> _repository;

        public SittingPlaceInfoService()
        {
            _repository = new Repository<SittingPlaceInfoDTO>();
        }

        public IEnumerable<SittingPlaceInfoDTO> Get()
        {
            return _repository.Get();
        }

        public IEnumerable<SittingPlaceInfoDTO> Get(Func<SittingPlaceInfoDTO, bool> predicate)
        {
            return _repository.Get(predicate);
        }

        public bool Create(SittingPlaceInfoDTO sittingPlaceInfoDto)
        {
            if (!IsSittingPlaceInfoDTOValid(sittingPlaceInfoDto))
            {
                return false;
            }

            try
            {
                _repository.Create(sittingPlaceInfoDto);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Remove(SittingPlaceInfoDTO sittingPlaceInfoDto)
        {
            if (!IsSittingPlaceInfoDTOValid(sittingPlaceInfoDto))
            {
                return false;
            }

            try
            {
                _repository.Remove(sittingPlaceInfoDto);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Update(SittingPlaceInfoDTO sittingPlaceInfoDto)
        {
            if (!IsSittingPlaceInfoDTOValid(sittingPlaceInfoDto))
            {
                return false;
            }

            try
            {
                _repository.Update(sittingPlaceInfoDto);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }


        private bool IsSittingPlaceInfoDTOValid(SittingPlaceInfoDTO sittingPlaceInfoDto)
        {
            return sittingPlaceInfoDto.Price > 0;
        }
    }
}