using System;
using System.Collections.Generic;
using Cinema.DAL.Entities;

namespace Cinema.Services.DTO
{
    public class HallDTO
    {
        public Guid Id { get; set; }
        public IEnumerable<SittingPlace> Places { get; set; }
    }
}