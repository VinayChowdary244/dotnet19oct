using System.ComponentModel.DataAnnotations.Schema;

namespace BusTicketingWebApplication.Models
{
    public class Booking
    {

        public int BookingId { get; set; }
        public string Username { get; set; }

        [ForeignKey("Username")]
        public User User { get; set; }
    }
}
