using System;

namespace Cinema.DAL.Entities
{
    public class FilmEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        
    }
}