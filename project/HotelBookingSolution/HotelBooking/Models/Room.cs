using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string? Type { get; set; }

        public int Charge { get; set; }
        public int? HotelId { get; set; }

        [ForeignKey("HotelId")]
        public Hotel? Hotel { get; set; }
        public bool AvailableStatus { get; set; }
    }
}
