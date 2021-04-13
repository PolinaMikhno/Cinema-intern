using System.Collections.Generic;

namespace Cinema.DAL.Entities
{
    public class Hall
    {
        public IEnumerable<SittingPlace> Places { get; set; }
    }
}