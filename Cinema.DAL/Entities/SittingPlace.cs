﻿using System;
using Cinema.DAL.Enums;

namespace Cinema.DAL.Entities
{
    public class SittingPlace
    {
        public Guid Id { get; set; }

        public int Number { get; set; }
        public int Row { get; set; }

        public SittingPlaceType SittingPlaceType { get; set; }
    }
}