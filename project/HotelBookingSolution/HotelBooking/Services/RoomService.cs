using HotelBooking.Interfaces;
using HotelBooking.Models;
using HotelBooking.Repositories;
using Microsoft.Extensions.Logging;
using HotelBooking.Exceptions;
namespace HotelBooking.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public Room Add(Room room)
        {
            var newRoom = new Room
            {
                HotelId = room.HotelId,
                
                Charge = room.Charge,
                AvailableStatus = room.AvailableStatus

            };
            
            return _roomRepository.Add(room);
            
        }

        public List<Room> GetRooms()
        {
            var room = _roomRepository.GetAll();
            if (room != null)
            {
                return room.ToList();
            }
            throw new NoRoomsAvailableException();
        }

        public Room Remove(Room room)
        {
            var RoomId = _roomRepository.GetAll().FirstOrDefault(r => r.RoomId == room.RoomId);
            if (RoomId != null)
            {
                var result = _roomRepository.Delete(RoomId.RoomId);
                if (result != null) return result;
            }
            return RoomId;
        }

        public Room Update(Room room)
        {
            throw new NotImplementedException();
        }
    }
}
