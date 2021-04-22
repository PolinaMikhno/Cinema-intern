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
        private Repository<TheaterModel> _repository;

        public TheaterService()
        {
            _repository = new Repository<TheaterModel>();
        }

        public IEnumerable<TheaterModel> Get()
        {
            return _repository.Get();
        }

        public IEnumerable<TheaterModel> Get(Func<TheaterModel, bool> predicate)
        {
            return _repository.Get(predicate);
        }

        public bool Create(TheaterModel theaterModel)
        {
            if (!IsTheaterDTOValid(theaterModel))
            {
                return false;
            }

            try
            {
                _repository.Create(theaterModel);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Remove(TheaterModel theaterModel)
        {
            if (!IsTheaterDTOValid(theaterModel))
            {
                return false;
            }

            try
            {
                _repository.Remove(theaterModel);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Update(TheaterModel theaterModel)
        {
            if (!IsTheaterDTOValid(theaterModel))
            {
                return false;
            }

            try
            {
                _repository.Update(theaterModel);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        private bool IsTheaterDTOValid(TheaterModel theaterModel)
        {

            return theaterModel.Halls.Any();
        }
    }
}