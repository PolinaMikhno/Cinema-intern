using System;

namespace Cinema.DAL.Entities
{
    public class Film
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
        public DateTime ShowStart { get; set; }
        public DateTime ShowEnd { get; set; }
        
    }
}