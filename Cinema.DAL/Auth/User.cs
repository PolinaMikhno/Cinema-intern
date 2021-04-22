using System;
using System.Collections.Generic;
using Cinema.DAL.Entities;

namespace Cinema.DAL.Auth
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        // admin, user
        // cinema admin???
        public string Role { get; set; }

        public IEnumerable<TicketEntity> Tickets { get; set; }
    }
}