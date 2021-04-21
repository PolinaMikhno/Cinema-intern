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
        private Repository<TicketDTO> _repository;

        public TicketService()
        {
            _repository = new Repository<TicketDTO>();
        }

        public IEnumerable<TicketDTO> Get()
        {
            return _repository.Get();
        }

        public IEnumerable<TicketDTO> Get(Func<TicketDTO, bool> predicate)
        {
            return _repository.Get(predicate);
        }

        public bool Create(TicketDTO ticketDTO)
        {
            if (!IsTicketDTOValid(ticketDTO))
            {
                return false;
            }

            try
            {
                _repository.Create(ticketDTO);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Remove(TicketDTO ticketDTO)
        {
            if (!IsTicketDTOValid(ticketDTO))
            {
                return false;
            }

            try
            {
                _repository.Remove(ticketDTO);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Update(TicketDTO ticketDTO)
        {
            if (!IsTicketDTOValid(ticketDTO))
            {
                return false;
            }

            try
            {
                _repository.Update(ticketDTO);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        private bool IsTicketDTOValid(TicketDTO ticketDTO)
        {
            if (ticketDTO.Session != null && ticketDTO.Places.Any() && ticketDTO.Price > 0)
            {
                return true;
            }

            return false;
        }
    }
}