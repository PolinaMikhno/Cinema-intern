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
        private Repository<SessionDTO> _repository;

        public SessionService()
        {
            _repository = new Repository<SessionDTO>();
        }

        public IEnumerable<SessionDTO> Get()
        {
            return _repository.Get();
        }

        public IEnumerable<SessionDTO> Get(Func<SessionDTO, bool> predicate)
        {
            return _repository.Get(predicate);
        }

        public bool Create(SessionDTO sessionDto)
        {
            if (!IsSessionDTOValid(sessionDto))
            {
                return false;
            }

            try
            {
                _repository.Create(sessionDto);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Remove(SessionDTO sessionDto)
        {
            if (!IsSessionDTOValid(sessionDto))
            {
                return false;
            }

            try
            {
                _repository.Remove(sessionDto);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Update(SessionDTO sessionDto)
        {
            if (!IsSessionDTOValid(sessionDto))
            {
                return false;
            }

            try
            {
                _repository.Update(sessionDto);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public IEnumerable<SessionDTO> GetFutureSessionDTOs()
        {
            DateTime now = DateTime.Now;
            return _repository.Get(s => DateTime.Compare(s.Start, now) > 0);
        }


        private bool IsSessionDTOValid(SessionDTO sessionDto)
        {
            if (sessionDto != null && sessionDto.Theater != null && sessionDto.Hall != null)
            {
                return sessionDto.Theater.Halls.Contains(sessionDto.Hall) && sessionDto.Film != null;
            }

            return false;
        }
    }
}