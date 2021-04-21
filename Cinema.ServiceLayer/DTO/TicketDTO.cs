using System;
using System.Collections.Generic;
using Cinema.DAL.Entities;
using Cinema.DAL.Entities.Sessions;

namespace Cinema.Services.DTO
{
    public class TicketDTO
    {
        public Guid Id { get; set; }
        public Session Session { get; set; }
        public IEnumerable<SittingPlace> Places { get; set; }
        public decimal Price { get; set; }
    }
}