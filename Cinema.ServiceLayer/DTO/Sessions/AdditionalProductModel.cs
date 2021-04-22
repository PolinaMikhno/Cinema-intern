using System;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Services.DTO.Sessions
{
    public class AdditionalProductModel
    {
        [Required] public Guid Id { get; set; }

        [Required] public string Name { get; set; }

        [Required] public string Description { get; set; }

        [Range(float.Epsilon, (double) decimal.MaxValue, ErrorMessage = "Price must be positive")]
        public decimal Price { get; set; }
    }
}