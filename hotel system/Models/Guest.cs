using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Models
{
    public class Guest
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}
