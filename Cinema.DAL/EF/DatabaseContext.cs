using Cinema.DAL.Entities;
using Cinema.DAL.Entities.Sessions;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DAL.EF
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

        public DatabaseContext()
        {
            Database.EnsureCreated();
        }
    }
}