using Microsoft.EntityFrameworkCore;

namespace Cinema.API.Models
{
    public sealed class CinemaContext : DbContext
    {
        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<SomeItem> Items { get; set; }
    }
}