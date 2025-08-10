using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelManagementSystem.Models;

namespace HotelManagementSystem.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        void MakeBooking(Booking booking);
        List<Booking> GetAllBookings();
        Booking? GetBookingByRoomId(int roomId);
        Booking? SearchByGuestName(string name);
        Booking? GetHighestPayingBooking();
        void CancelBooking(int roomId);
    }
}

