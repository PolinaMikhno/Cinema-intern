using System;
using System.ComponentModel.DataAnnotations;
using Cinema.DAL.Enums;

namespace Cinema.Services.DTO
{
    public class SittingPlaceModel
    {
        [Required]
        public Guid Id { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Place Number must be positive")]
        public int Number { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Place Row must be positive")]
        public int Row { get; set; }
        [Required]
        public SittingPlaceType SittingPlaceType { get; set; }
    }
}