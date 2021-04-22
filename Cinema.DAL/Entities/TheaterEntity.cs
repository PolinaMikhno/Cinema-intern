using System;
using System.Collections.Generic;

namespace Cinema.DAL.Entities
{
    public class TheaterEntity
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        public string City { get; set; }
        public IEnumerable<HallEntity> Halls { get; set; }
    }
}