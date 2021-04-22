using System;
using System.Collections.Generic;

namespace Cinema.DAL.Entities.Sessions
{
    public class SessionEntity
    {
        public Guid Id { get; set; }
        
        public FilmEntity FilmEntity { get; set; } // which film to show on session
        public TheaterEntity TheaterEntity { get; set; } // where (banana)
        public HallEntity HallEntity { get; set; } // where in theater
        public DateTime Start { get; set; } // when (banana)
        public IEnumerable<AdditionalProductEntity> AdditionalServices { get; set; }
    }
}