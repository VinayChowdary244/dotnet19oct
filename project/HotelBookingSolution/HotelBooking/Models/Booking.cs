using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Models
{
    public class Booking
    {
       
            public int Id { get; set; }
            public DateTime CheckIn { get; set; }
            public DateTime CheckOut { get; set; }
            public string UserName { get; set; }
            public int RoomId { get; set; }
            [ForeignKey("RoomId")]
            public Room? Room { get; set; }

    }
}
