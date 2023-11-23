using HotelBooking.Contexts;
using HotelBooking.Interfaces;
using HotelBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly HotelContext _context;

        public BookingRepository(HotelContext context)
        {
            _context = context;
        }
        public Booking Add(Booking entity)
        {
            _context.Bookings.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Booking Delete(int key)
        {
            var booking = GetById(key);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
                return booking;
            }
            return null;
        }

        public IList<Booking> GetAll()
        {
            if (_context.Bookings.Count() == 0)
                return null;
            return _context.Bookings.ToList();
        }

        public Booking GetById(int key)
        {
            var booking = _context.Bookings.SingleOrDefault(b => b.Id == key);
            return booking;
        }

        public Booking Update(Booking entity)
        {
            var booking = GetById(entity.Id);
            if (booking != null)
            {
                _context.Entry<Booking>(booking).State = EntityState.Modified;
                _context.SaveChanges();
                return booking;
            }
            return null;
        }
    }
}
