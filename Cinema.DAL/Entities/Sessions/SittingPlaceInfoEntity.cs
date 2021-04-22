using System;

namespace Cinema.DAL.Entities.Sessions
{
    public class SittingPlaceInfoEntity
    {
        public Guid Id { get; set; }
        public SittingPlaceEntity PlaceEntity { get; set; }
        public decimal Price { get; set; }
    }
}