using Cinema.DAL.Entities;
using Cinema.DAL.Entities.Sessions;
using Microsoft.EntityFrameworkCore;
using User = Cinema.DAL.Auth.User;

namespace Cinema.DAL.EF
{
    public sealed class CinemaContext : DbContext
    {
        public DbSet<FilmEntity> Films;
        public DbSet<TheaterEntity> Theaters;
        public DbSet<SessionEntity> Sessions;

        public DbSet<TicketEntity> Tickets;
        
        public DbSet<User> Users;

        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public CinemaContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmEntity>().ToTable("Films");
            modelBuilder.Entity<TheaterEntity>().ToTable("Theaters");
            modelBuilder.Entity<SessionEntity>().ToTable("Sessions");
            modelBuilder.Entity<User>().ToTable("Users");
            
            modelBuilder.Entity<AdditionalProductEntity>().ToTable("AdditionalServices");
            modelBuilder.Entity<HallEntity>().ToTable("Halls");
            modelBuilder.Entity<SittingPlaceEntity>().ToTable("SittingPlaces");
            modelBuilder.Entity<TicketEntity>().ToTable("Tickets");

        }
    }
}