namespace BusTicketingWebApplication.Models.DTOs
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int BusId { get; set; }
        public String Date { get; set; }
        public List<int> SelectedSeats { get; set; }
        //public int NoOfSeats { get; set; }
    }
}
