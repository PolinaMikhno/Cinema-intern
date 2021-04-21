using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.DAL.EF;
using Cinema.Services.DTO;
using Serilog;

namespace Cinema.Services.Services
{
    public class TheaterService
    {
        private Repository<TheaterDTO> _repository;

        public TheaterService()
        {
            _repository = new Repository<TheaterDTO>();
        }

        public IEnumerable<TheaterDTO> Get()
        {
            return _repository.Get();
        }

        public IEnumerable<TheaterDTO> Get(Func<TheaterDTO, bool> predicate)
        {
            return _repository.Get(predicate);
        }

        public bool Create(TheaterDTO theaterDto)
        {
            if (!IsTheaterDTOValid(theaterDto))
            {
                return false;
            }

            try
            {
                _repository.Create(theaterDto);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Remove(TheaterDTO theaterDto)
        {
            if (!IsTheaterDTOValid(theaterDto))
            {
                return false;
            }

            try
            {
                _repository.Remove(theaterDto);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Update(TheaterDTO theaterDto)
        {
            if (!IsTheaterDTOValid(theaterDto))
            {
                return false;
            }

            try
            {
                _repository.Update(theaterDto);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        private bool IsTheaterDTOValid(TheaterDTO theaterDto)
        {

            return theaterDto.Halls.Any();
        }
    }
}