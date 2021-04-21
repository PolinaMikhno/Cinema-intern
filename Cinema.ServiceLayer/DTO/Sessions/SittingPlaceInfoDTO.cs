using System;
using Cinema.DAL.Entities;

namespace Cinema.Services.DTO.Sessions
{
    public class SittingPlaceInfoDTO
    {
        public Guid Id { get; set; }
        public SittingPlace Place { get; set; }
        public decimal Price { get; set; }
    }
}