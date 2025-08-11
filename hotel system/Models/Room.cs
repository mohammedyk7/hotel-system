using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // for [Index]
using Microsoft.EntityFrameworkCore;               // if your [Index] comes from EF Core
                                                

namespace HotelManagementSystem.Models
{
    [Index(nameof(RoomNumber), IsUnique = true)] // Unique room number
    //create a databse index + no two rooms can have the samew number 
    public class Room
    {
        public int Id { get; set; }

        [Required]
        public int RoomNumber { get; set; }
        [Required]
        [Precision(10, 2)]
        [Range(typeof(decimal), "100", "9999999999")] // min >= 100 atleast .
        public decimal DailyRate { get; set; }

        public bool IsReserved { get; set; }// true if reserved, false if available

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();// a room can have many bookings
        public ICollection<Review> Reviews { get; set; } = new List<Review>();// a room can have many reviews

    }
}
