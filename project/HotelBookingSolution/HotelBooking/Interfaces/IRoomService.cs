using HotelBooking.Models;

namespace HotelBooking.Interfaces
{
    public interface IRoomService
    {
        List<Room> GetRooms();
        Room Add(Room room);
        Room Remove(Room room);
        Room Update(Room room);
    }
}
