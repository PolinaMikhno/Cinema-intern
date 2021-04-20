using System;
using System.Collections.Generic;

namespace Cinema.DAL.Entities
{
    public class Hall
    {
        public Guid Id { get; set; }
        public IEnumerable<SittingPlace> Places { get; set; }
    }
}