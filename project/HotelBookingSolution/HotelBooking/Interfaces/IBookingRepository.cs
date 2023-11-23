using HotelBooking.Models;

namespace HotelBooking.Interfaces
{
    public interface IBookingRepository
    {
        Booking GetById(int key);
        IList<Booking> GetAll();
        Booking Add(Booking entity);
        Booking Update(Booking entity);
        Booking Delete(int key);
    }
}
