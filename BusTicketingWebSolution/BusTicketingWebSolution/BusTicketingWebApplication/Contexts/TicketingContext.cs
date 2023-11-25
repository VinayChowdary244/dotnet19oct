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
        public DbSet<Bus>Buses { get; set; }
        public DbSet<Booking>Bookings { get; set; }
        public DbSet<BusRoute>BusRoutes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .Property(b => b.SelectedSeats)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()
                );
        }
    }
}
