using System.Collections.Generic;

namespace Cinema.DAL.Entities
{
    public class Theater
    {
        public string Name { get; set; }
        public string City { get; set; }
        public IEnumerable<Hall> Halls { get; set; }
    }
}