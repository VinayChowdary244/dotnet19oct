using BusTicketingWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BusTicketingWebApplication.Contexts
{
    public class TicketingContext : DbContext
    {
        public TicketingContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Bus> Busses { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
