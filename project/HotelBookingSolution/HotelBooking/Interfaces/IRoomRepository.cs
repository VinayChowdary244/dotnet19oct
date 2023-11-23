using HotelBooking.Models;

namespace HotelBooking.Interfaces
{
    public interface IRoomRepository
    {
        Room GetById(int key);
        IList<Room> GetAll();
        Room Add(Room entity);
        Room Update(Room entity);
        Room Delete(int key);
    }
}
