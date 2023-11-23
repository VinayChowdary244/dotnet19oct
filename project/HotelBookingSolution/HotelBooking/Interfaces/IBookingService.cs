using HotelBooking.Models;

namespace HotelBooking.Interfaces
{
    public interface IBookingService
    {
        List<Booking> GetBookings();
        Booking Add(Booking booking);
        
    }
}
