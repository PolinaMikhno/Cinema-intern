using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.DAL.EF;
using Cinema.DAL.Entities.Sessions;
using Cinema.Services.DTO.Sessions;
using Serilog;

namespace Cinema.Services.Services
{
    public class SessionService
    {
        private Repository<SessionModel> _repository;

        public SessionService()
        {
            _repository = new Repository<SessionModel>();
        }

        public IEnumerable<SessionModel> Get()
        {
            return _repository.Get();
        }

        public IEnumerable<SessionModel> Get(Func<SessionModel, bool> predicate)
        {
            return _repository.Get(predicate);
        }

        public bool Create(SessionModel sessionModel)
        {

            try
            {
                _repository.Create(sessionModel);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Remove(SessionModel sessionModel)
        {
            try
            {
                _repository.Remove(sessionModel);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Update(SessionModel sessionModel)
        {

            try
            {
                _repository.Update(sessionModel);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public IEnumerable<SessionModel> GetFutureSessionDTOs()
        {
            DateTime now = DateTime.Now;
            return _repository.Get(s => DateTime.Compare(s.Start, now) > 0);
        }

        
    }
}