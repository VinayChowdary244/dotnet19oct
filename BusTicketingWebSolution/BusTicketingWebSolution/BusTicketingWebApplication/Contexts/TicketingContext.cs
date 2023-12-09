using BusModelLibrary;
using BusTicketingWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BusTicketingWebApplication.Contexts
{
    public class TicketingContext:DbContext
    {
        public TicketingContext(DbContextOptions options) :base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Bus>Busses { get; set; }
        public DbSet<Booking>Bookings { get; set; }
        public DbSet<BusRoute>BusRoutes { get; set; }
        public DbSet<BookedSeat> BookedSeats { get; set; }
        //public DbSet<UpcomingJourney> UpcomingJourneys { get; set; }
        public DbSet<CancelledBooking> CancelledBookings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .Property(b => b.SelectedSeats)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()
                );

            modelBuilder.Entity<BookedSeat>()
               .Property(b => b.BookedSeats)
               .HasConversion(
                   v => string.Join(',', v),
                   v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()
               );

            modelBuilder.Entity<CancelledBooking>()
               .Property(b => b.CancelledSeats)
               .HasConversion(
                   v => string.Join(',', v),
                   v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()
               );
        }
    }
}
