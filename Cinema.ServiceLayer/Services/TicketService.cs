using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.DAL.EF;
using Cinema.DAL.Entities;
using Cinema.DAL.Entities.Sessions;
using Cinema.Services.DTO;
using Serilog;

namespace Cinema.Services.Services
{
    public class TicketService
    {
        private Repository<TicketModel> _repository;

        public TicketService()
        {
            _repository = new Repository<TicketModel>();
        }

        public IEnumerable<TicketModel> Get()
        {
            return _repository.Get();
        }

        public IEnumerable<TicketModel> Get(Func<TicketModel, bool> predicate)
        {
            return _repository.Get(predicate);
        }

        public bool Create(TicketModel ticketModel)
        {
            if (!IsTicketDTOValid(ticketModel))
            {
                return false;
            }

            try
            {
                _repository.Create(ticketModel);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Remove(TicketModel ticketModel)
        {
            if (!IsTicketDTOValid(ticketModel))
            {
                return false;
            }

            try
            {
                _repository.Remove(ticketModel);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Update(TicketModel ticketModel)
        {
            if (!IsTicketDTOValid(ticketModel))
            {
                return false;
            }

            try
            {
                _repository.Update(ticketModel);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        private bool IsTicketDTOValid(TicketModel ticketModel)
        {
            if (ticketModel.SessionEntity != null && ticketModel.Places.Any() && ticketModel.Price > 0)
            {
                return true;
            }

            return false;
        }
    }
}