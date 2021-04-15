﻿using System;
using System.Collections.Generic;

namespace Cinema.DAL.Entities.Sessions
{
    public class Session
    {
        public Film Film { get; set; } // which film to show on session
        public Theater Theater { get; set; } // where (banana)
        public Hall Hall { get; set; } // where in theater
        public DateTime Start { get; set; } // when (banana)
        public IEnumerable<AdditionalService> AdditionalServices { get; set; }
    }
}