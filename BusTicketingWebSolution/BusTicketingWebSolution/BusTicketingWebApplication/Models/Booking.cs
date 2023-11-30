﻿using System.ComponentModel.DataAnnotations;

namespace BusTicketingWebApplication.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        
        public string UserName{ get; set; }
        public int BusId { get; set; }
        public  string? Date { get; set; }
        public List<int> SelectedSeats { get; set; }
        //public int NoOfSeats { get; set; }
        public float TotalFare { get; set; }

        //public string? SrartTime  { get; set; }
        //public string? EndTime { get; set; }

    }
}
