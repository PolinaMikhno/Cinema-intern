using System;
using System.Collections.Generic;

namespace Cinema.DAL.Entities
{
    public class HallEntity
    {
        public Guid Id { get; set; }
        public IEnumerable<SittingPlaceEntity> Places { get; set; }
    }
}