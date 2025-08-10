using HotelManagementSystem.Models;
using HotelManagementSystem.Data;
using HotelManagementSystem.Repositories.Interfaces;
//using hotel_system.Repositories.Interfaces;
using HotelManagementSystem.Repositories.Implementation;


namespace HotelManagementSystem.Repositories.Implementation
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext _context;//it can only be set once (in the constructor).

        public RoomRepository(AppDbContext context)
        {
            _context = context;// this is how we inject the context into the repository
        }

        public void AddRoom(Room room)
        {
            _context.Rooms.Add(room);// this will add the room to the database
            _context.SaveChanges();//  this will save the changes to the database
        }

        public List<Room> GetAllRooms()
        {
            return _context.Rooms.ToList();// this will return all the rooms from the database
        }

        public Room? GetRoomById(int id)
        {
            return _context.Rooms.Find(id);// this will return the room with the given id or null if not found
            
        }

        public void ReserveRoom(int id)
        {
            var room = _context.Rooms.Find(id);
            if (room != null && !room.IsReserved)
            {
                room.IsReserved = true;
                _context.SaveChanges();
            }
        }
    }
}
