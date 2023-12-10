
using System.ComponentModel.DataAnnotations;

namespace BusTicketingWebApplication.Models
{
    public class BookedSeat
    {
        [Key]
        public int Id { get; set; }
        public List<int> BookedSeats { get; set; }
        public int AvailableSeats { get; set; }
        public int? BookedSeatCount { get; set; }
        public int BusId { get; set;}
        public String Date { get; set; }
        //demo
        //trial for context.

       // public Ticket Ticket { get; set; }
    }
}
