using System.ComponentModel.DataAnnotations;

namespace BusTicketingWebApplication.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        
        public int UserId { get; set; }
        public int BusId { get; set; }
        public  string? Date { get; set; }
        //public string? SrartTime  { get; set; }
        //public string? EndTime { get; set; }

    }
}
