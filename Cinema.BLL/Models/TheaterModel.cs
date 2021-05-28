using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Cinema.DAL.Entities;

namespace Cinema.Services.Models
{
    public class TheaterModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public IEnumerable<HallEntity> Halls { get; set; }
    }
}