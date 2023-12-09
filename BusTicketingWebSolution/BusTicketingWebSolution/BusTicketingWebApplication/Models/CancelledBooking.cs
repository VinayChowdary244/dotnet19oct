﻿using System.ComponentModel.DataAnnotations;

namespace BusTicketingWebApplication.Models
{
    public class CancelledBooking
    {
        [Key]
        public int CancellationId { get; set; }
        public int BookingId { get; set; }

        public string UserName { get; set; }
        public int BusId { get; set; }
        public string? Date { get; set; }
        public List<int> CancelledSeats { get; set; }
        public float TotalFare { get; set; }
        public DateTime CancelledDate { get; set; }

        //public string? SrartTime  { get; set; }
        //public string? Duration { get; set; }

    }
}
