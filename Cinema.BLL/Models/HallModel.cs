using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Cinema.DAL.Entities;

namespace Cinema.Services.DTO
{
    public class HallModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public IEnumerable<SittingPlaceEntity> Places { get; set; }
    }
}