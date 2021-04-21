using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.DAL.EF;
using Cinema.Services.DTO;
using Serilog;

namespace Cinema.Services.Services
{
    public class HallService
    {
        private Repository<HallDTO> _repository;

        public HallService()
        {
            _repository = new Repository<HallDTO>();
        }

        public IEnumerable<HallDTO> Get()
        {
            return _repository.Get();
        }

        public IEnumerable<HallDTO> Get(Func<HallDTO, bool> predicate)
        {
            return _repository.Get(predicate);
        }

        public bool Create(HallDTO hallDto)
        {
            if (!IsHallDTOValid(hallDto))
            {
                return false;
            }

            try
            {
                _repository.Create(hallDto);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Remove(HallDTO hallDto)
        {
            if (!IsHallDTOValid(hallDto))
            {
                return false;
            }

            try
            {
                _repository.Remove(hallDto);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Update(HallDTO hallDto)
        {
            if (!IsHallDTOValid(hallDto))
            {
                return false;
            }

            try
            {
                _repository.Update(hallDto);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }
        
        private bool IsHallDTOValid(HallDTO hallDto)
        {
            return hallDto.Places.Any();
        }
    }
}