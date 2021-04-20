using Cinema.DAL.Entities;
using Cinema.DAL.Entities.Sessions;
using Microsoft.EntityFrameworkCore;
using User = Cinema.DAL.Auth.User;

namespace Cinema.DAL.EF
{
    public sealed class CinemaContext : DbContext
    {
        public DbSet<Film> Films;
        public DbSet<Theater> Theaters;
        public DbSet<Session> Sessions;

        public DbSet<User> Users;

        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>().ToTable("Films");
            modelBuilder.Entity<Theater>().ToTable("Theaters");
            modelBuilder.Entity<Session>().ToTable("Sessions");
            modelBuilder.Entity<User>().ToTable("Users");

            modelBuilder.Entity<AdditionalService>().ToTable("AdditionalServices");
            modelBuilder.Entity<Hall>().ToTable("Halls");
            modelBuilder.Entity<SittingPlace>().ToTable("SittingPlaces");

        }
    }
}