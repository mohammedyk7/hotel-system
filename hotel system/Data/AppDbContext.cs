using HotelManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace HotelManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Room> Rooms => Set<Room>();//we have a table for rooms 
        public DbSet<Guest> Guests => Set<Guest>();// we have a table for guests 
        public DbSet<Booking> Bookings => Set<Booking>();//table for booking 
        public DbSet<Review> Reviews => Set<Review>();//table for review

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ROOM - Unique RoomNumber
            modelBuilder.Entity<Room>()
                .HasIndex(r => r.RoomNumber)// for every room , enter the room number 
                .IsUnique();

            modelBuilder.Entity<Guest>()
                .Property(g => g.Name)
                .HasDefaultValue("Unknown Guest") // Default value if not set , if the guest write their name it will automatically type unknown guest 
                .IsRequired();// Name cannot be null


            //needs to be separated 
            modelBuilder.Entity<Booking>()
                  .HasOne(b => b.Guest)       // Booking one Guest
                  .WithMany(g => g.Bookings) // Guest -- MANY BOOKINGSS
                  .HasForeignKey(b => b.GuestId); // FK to Guest


            modelBuilder.Entity<Booking>()
               .HasOne(b => b.Room)// Booking one Room
               .WithMany(r => r.Bookings)// Room -- MANY BOOKINGS
               .HasForeignKey(b => b.RoomId);// FK to Room


            // BOOKING  Optional Fluent API if needed
            modelBuilder.Entity<Booking>()

                .Property(b => b.TotalCost)
                .HasPrecision(10, 2) // Precision for money (10 digits total, 2 after decimal)
                .IsRequired(); // Total cost cannot be null

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Room) // Review one Room
                .WithMany(r => r.Reviews) // Room -- MANY REVIEWS
                .HasForeignKey(r => r.RoomId); // FK to Room

            // REVIEW - Limit rating to 1–5
            modelBuilder.Entity<Review>()
                .Property(r => r.Rating)// fluent api "."
                .HasDefaultValue(5);
                
        }
    }
}
