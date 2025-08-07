using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Models
{
    public class Review
    {
        public int Id { get; set; }

        public int GuestId { get; set; }
        public Guest? Guest { get; set; }

        public int RoomId { get; set; }
        public Room? Room { get; set; }

        public int Rating { get; set; } // 1 to 5
        public string? Comment { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}

