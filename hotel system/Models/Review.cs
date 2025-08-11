using System;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }  // default 5 via Fluent API

        public string? Comment { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;

        // FKs
        public int GuestId { get; set; }//fk
        public Guest Guest { get; set; } = null!;

        public int RoomId { get; set; }
        public Room Room { get; set; } = null!;
    }
}
