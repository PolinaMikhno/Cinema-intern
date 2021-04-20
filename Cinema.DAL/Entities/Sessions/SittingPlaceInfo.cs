using System;

namespace Cinema.DAL.Entities.Sessions
{
    public class SittingPlaceInfo
    {
        public Guid Id { get; set; }
        public SittingPlace Place { get; set; }
        public decimal Price { get; set; }
    }
}