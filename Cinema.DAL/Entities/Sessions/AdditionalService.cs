﻿using System;

namespace Cinema.DAL.Entities.Sessions
{
    public class AdditionalService
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
