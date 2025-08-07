using HotelManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace HotelManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Room> Rooms => Set<Room>();
        public DbSet<Guest> Guests => Set<Guest>();
        public DbSet<Booking> Bookings => Set<Booking>();
        public DbSet<Review> Reviews => Set<Review>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ROOM - Unique RoomNumber
            modelBuilder.Entity<Room>()
                .HasIndex(r => r.RoomNumber)
                .IsUnique();

            // BOOKING - Optional Fluent API if needed
            modelBuilder.Entity<Booking>()
                .Property(b => b.TotalCost)
                .HasColumnType("decimal(10,2)");

            // REVIEW - Limit rating to 1–5
            modelBuilder.Entity<Review>()
                .Property(r => r.Rating)
                .HasDefaultValue(5)
                .IsRequired();
        }
    }
}
