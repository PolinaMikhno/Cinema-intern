using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Cinema.DAL.Entities;
using Cinema.DAL.Entities.Sessions;

namespace Cinema.Services.DTO
{
    public class TicketModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public SessionEntity SessionEntity { get; set; }
        [Required]
        public IEnumerable<SittingPlaceEntity> Places { get; set; }
        [Range(float.Epsilon, (double) decimal.MaxValue, ErrorMessage = "Price must be positive")]
        public decimal Price { get; set; }
    }
}