using System;
using System.Collections.Generic;
using Cinema.DAL.Entities;

namespace Cinema.Services.DTO
{
    public class TheaterDTO
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        public string City { get; set; }
        public IEnumerable<Hall> Halls { get; set; }
    }
}