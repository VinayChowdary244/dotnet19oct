using HotelBooking.Exceptions;
using HotelBooking.Interfaces;
using HotelBooking.Models;

namespace HotelBooking.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }



        public Booking Add(Booking booking)
        {
            var result = _bookingRepository.Add(booking);
            return result;
        }

        public List<Booking> GetBookings()
        {
            throw new NotImplementedException();
        }

        public List<Booking> GetHotel()
        {
            var booking = _bookingRepository.GetAll();
            if (booking != null)
            {
                return booking.ToList();
            }
            throw new NoHotelAvailableException();
        }


        
    }
}
