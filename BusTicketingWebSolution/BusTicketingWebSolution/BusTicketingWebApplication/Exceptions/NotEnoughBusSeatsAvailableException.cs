namespace BusTicketingWebApplication.Exceptions
{
    public class NotEnoughBusSeatsAvailableException:Exception
    {
        string msg = "";
        public NotEnoughBusSeatsAvailableException()
        {
            msg = "Not enough Bus seats available for booking.";
        }
        public override string Message => msg;
    }
}
