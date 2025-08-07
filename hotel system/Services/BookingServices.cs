using HotelManagementSystem.Models;
using HotelManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Services
{
    public class BookingServices
    {
        private readonly AppDbContext _context;

        public BookingServices(AppDbContext context)
        {
            _context = context;
        }

        public void MakeBooking(int guestId, int roomId, int nights)
        {
            var room = _context.Rooms.Find(roomId);
            if (room == null || room.IsReserved) return;

            var booking = new Booking
            {
                GuestId = guestId,
                RoomId = roomId,
                Nights = nights,
                BookingDate = DateTime.Now,
                TotalCost = room.DailyRate * nights
            };

            room.IsReserved = true;
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public List<Booking> GetAllBookings()
        {
            return _context.Bookings
                .Include(b => b.Guest)
                .Include(b => b.Room)
                .ToList();
        }

        public void CancelBooking(int roomId)
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.RoomId == roomId);
            var room = _context.Rooms.Find(roomId);
            if (booking != null && room != null)
            {
                _context.Bookings.Remove(booking);
                room.IsReserved = false;
                _context.SaveChanges();
            }
        }

        public Booking? GetHighestPayingBooking()
        {
            return _context.Bookings
                .Include(b => b.Guest)
                .OrderByDescending(b => b.TotalCost)
                .FirstOrDefault();
        }

        public Booking? SearchByGuestName(string name)
        {
            return _context.Bookings
                .Include(b => b.Guest)
                .Include(b => b.Room)
                .FirstOrDefault(b => b.Guest!.Name.ToLower() == name.ToLower());
        }
    }
}
