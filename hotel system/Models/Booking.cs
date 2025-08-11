using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore; // for [Precision]

namespace HotelManagementSystem.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public DateTime BookingDate { get; set; } // default via Fluent API

        [Range(1, int.MaxValue)]
        public int Nights { get; set; }

        [Precision(10, 2)]
        public decimal TotalCost { get; set; } // set in service/repo before SaveChanges

        // FKs
        public int GuestId { get; set; }//FK
        public Guest Guest { get; set; } = null!;

        public int RoomId { get; set; }
        public Room Room { get; set; } = null!;
    }
}
