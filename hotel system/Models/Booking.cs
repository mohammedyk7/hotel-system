using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagementSystem.Models;


namespace HotelManagementSystem.Models
{
    public class Booking
    {
        public int Id { get; set; }// Unique identifier for the booking

        public int GuestId { get; set; }
        public Guest? Guest { get; set; }

        public int RoomId { get; set; }
        public Room? Room { get; set; }

        public int Nights { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.Now;

        public decimal TotalCost { get; set; } // We'll calculate this in the service layer
    }
}
