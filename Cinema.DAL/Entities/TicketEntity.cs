using System;
using System.Collections.Generic;
using Cinema.DAL.Entities.Sessions;

namespace Cinema.DAL.Entities
{
    public class TicketEntity
    {
        public Guid Id { get; set; }
        public SessionEntity SessionEntity { get; set; }
        public IEnumerable<SittingPlaceEntity> Places { get; set; }
        public decimal Price { get; set; }
    }
}