using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelManagementSystem.Models;

namespace HotelManagementSystem.Repositories.Interfaces
{
    public interface IGuestRepository
    {
        void AddGuest(Guest guest);
        Guest? GetGuestById(int id);
        Guest? FindGuestByName(string name);
        List<Guest> GetAllGuests();
    }
}

