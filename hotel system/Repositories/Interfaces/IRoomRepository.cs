using HotelManagementSystem.Models;

namespace HotelManagementSystem.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        void AddRoom(Room room);
        List<Room> GetAllRooms();
        Room? GetRoomById(int id);
        void ReserveRoom(int id);
    }
}
