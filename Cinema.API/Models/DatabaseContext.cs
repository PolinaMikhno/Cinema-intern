using Cinema.DAL.Entities;
using Cinema.DAL.Entities.Sessions;
using Microsoft.EntityFrameworkCore;

namespace Cinema.API.Models
{
    public sealed class DatabaseContext : DbContext
    {
        public DbSet<Film> Films;
        public DbSet<Theater> Theaters;
        public DbSet<Session> Sessions;
        
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}