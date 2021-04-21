using System;

namespace Cinema.Services.DTO
{
    public class FilmDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}