using System.Collections.Generic;
using Cinema.DAL.Entities.Sessions;

namespace Cinema.DAL.Entities
{
    public class Ticket
    {
        public Session Session { get; set; }
        public IEnumerable<SittingPlace> Places { get; set; }
        public decimal Price { get; set; }
    }
}