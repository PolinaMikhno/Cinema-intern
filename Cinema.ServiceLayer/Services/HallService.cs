using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.DAL.EF;
using Cinema.Services.DTO;
using Serilog;

namespace Cinema.Services.Services
{
    public class HallService: IService<HallModel>
    {
        private Repository<HallModel> _repository;

        public HallService(Repository<HallModel> repository)
        {
            _repository = repository;
        }

        public IEnumerable<HallModel> Get()
        {
            return _repository.Get();
        }

        public IEnumerable<HallModel> Get(Func<HallModel, bool> predicate)
        {
            return _repository.Get(predicate);
        }

        public bool Create(HallModel hallModel)
        {
            if (!IsHallDTOValid(hallModel))
            {
                return false;
            }

            try
            {
                _repository.Create(hallModel);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Remove(HallModel hallModel)
        {
            if (!IsHallDTOValid(hallModel))
            {
                return false;
            }

            try
            {
                _repository.Remove(hallModel);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Update(HallModel hallModel)
        {
            if (!IsHallDTOValid(hallModel))
            {
                return false;
            }

            try
            {
                _repository.Update(hallModel);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }
        
        private bool IsHallDTOValid(HallModel hallModel)
        {
            return hallModel.Places.Any();
        }
    }
}