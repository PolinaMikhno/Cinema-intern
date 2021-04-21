using System;
using System.Collections.Generic;
using Cinema.DAL.Entities;
using Cinema.DAL.Entities.Sessions;

namespace Cinema.Services.DTO.Sessions
{
    public class SessionDTO
    {
        public Guid Id { get; set; }
        
        public Film Film { get; set; }
        public Theater Theater { get; set; }
        public Hall Hall { get; set; }
        public DateTime Start { get; set; }
        public IEnumerable<AdditionalProduct> AdditionalServices { get; set; }
    }
}