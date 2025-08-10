using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // for [Index]
using Microsoft.EntityFrameworkCore;               // if your [Index] comes from EF Core
                                                   // (EF Core 5+ supports [Index])

namespace HotelManagementSystem.Models
{
    [Index(nameof(RoomNumber), IsUnique = true)] // Unique room number
    public class Room
    {
        public int Id { get; set; }

        [Required]
        public int RoomNumber { get; set; }

        // Use decimal for money; set precision to (10,2).
        [Required]
        [Precision(10, 2)] // EF Core 6+
        [Range(typeof(decimal), "100", "9999999999")] // min >= 100
        public decimal DailyRate { get; set; }

        public bool IsReserved { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
