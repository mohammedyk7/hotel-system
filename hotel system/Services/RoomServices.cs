using HotelManagementSystem.Models;
using HotelManagementSystem.Repositories.Interfaces;

namespace HotelManagementSystem.Services
{
    public class RoomServices
    {
        private readonly IRoomRepository _roomRepo;

        public RoomServices(IRoomRepository roomRepo)
        {
            _roomRepo = roomRepo;
        }

        public void AddRoom(Room room)
        {
            _roomRepo.AddRoom(room);
        }

        public List<Room> GetAllRooms()
        {
            return _roomRepo.GetAllRooms();
        }

        public Room? GetRoomById(int id)
        {
            return _roomRepo.GetRoomById(id);
        }

        public void ReserveRoom(int id)
        {
            _roomRepo.ReserveRoom(id);
        }
    }
}
