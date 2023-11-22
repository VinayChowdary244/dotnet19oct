namespace BusTicketingWebApplication.Models
{
    public class ScheduleMaster
    {
        public int ScheduleId { get; set; }
        public int BusId { get; set; }
        public string Date { get; set; }
        public float fare { get; set; }
        public string ArrivalTime { get; set; }
        public int BookedSeats { get; set; }
        public int AvailableSeats { get; set; }
        public int RoutId { get; set; }

        public string DepartureTime { get; set; }

    }
}
