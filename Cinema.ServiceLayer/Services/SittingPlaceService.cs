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
        private Repository<SittingPlaceDTO> _repository;

        public SittingPlaceService()
        {
            _repository = new Repository<SittingPlaceDTO>();
        }

        public IEnumerable<SittingPlaceDTO> Get()
        {
            return _repository.Get();
        }

        public IEnumerable<SittingPlaceDTO> Get(Func<SittingPlaceDTO, bool> predicate)
        {
            return _repository.Get(predicate);
        }

        public bool Create(SittingPlaceDTO sittingPlaceDto)
        {
            if (!IsSittingPlaceDTOValid(sittingPlaceDto))
            {
                return false;
            }

            try
            {
                _repository.Create(sittingPlaceDto);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Remove(SittingPlaceDTO sittingPlaceDto)
        {
            if (!IsSittingPlaceDTOValid(sittingPlaceDto))
            {
                return false;
            }

            try
            {
                _repository.Remove(sittingPlaceDto);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Update(SittingPlaceDTO sittingPlaceDto)
        {
            if (!IsSittingPlaceDTOValid(sittingPlaceDto))
            {
                return false;
            }

            try
            {
                _repository.Update(sittingPlaceDto);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        private bool IsSittingPlaceDTOValid(SittingPlaceDTO sittingPlaceDto)
        {
            if (sittingPlaceDto != null && sittingPlaceDto.Number > 0 && sittingPlaceDto.Row > 0)
            {
                return true;
            }

            return false;
        }
    }
}