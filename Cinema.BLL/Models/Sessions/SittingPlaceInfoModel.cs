using System;
using System.ComponentModel.DataAnnotations;
using Cinema.DAL.Entities;

namespace Cinema.Services.DTO.Sessions
{
    public class SittingPlaceInfoModel
    {
        [Required] public Guid Id { get; set; }
        [Required] public SittingPlaceEntity PlaceEntity { get; set; }

        [Range(float.Epsilon, (double) decimal.MaxValue, ErrorMessage = "Price must be positive")]
        public decimal Price { get; set; }
    }
}