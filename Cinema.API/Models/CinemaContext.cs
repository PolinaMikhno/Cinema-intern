﻿using Microsoft.EntityFrameworkCore;

namespace Cinema.API.Models
{
    public class CinemaContext : DbContext
    {
        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options)
        {

        }

        public DbSet<SomeItem> Items { get; set; }
    }
}