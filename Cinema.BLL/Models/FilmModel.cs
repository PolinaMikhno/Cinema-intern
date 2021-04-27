using System;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Services.DTO
{
    public class FilmModel
    {
        [Required] public Guid Id { get; set; }
        [Required] public string Name { get; set; }

        public string Description { get; set; }
        [Required] public DateTime Start { get; set; }
        [Required] public DateTime End { get; set; }
    }
}