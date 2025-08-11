using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelManagementSystem.Models;

namespace HotelManagementSystem.Repositories.Interfaces
{
    public interface IBookingRepository//
    {
        void MakeBooking(Booking booking);// booking is an object of type Booking
        List<Booking> GetAllBookings();// returns a list of all bookings
        Booking? GetBookingByRoomId(int roomId);// returns a booking by room id
        Booking? SearchByGuestName(string name);
        Booking? GetHighestPayingBooking();
        void CancelBooking(int roomId);
    }
}

