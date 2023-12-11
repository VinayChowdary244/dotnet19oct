namespace BusTicketingWebApplication.Exceptions
{
    public class NoCancelledBookingsException: Exception
    {

        string msg = "";
        public NoCancelledBookingsException()
        {
            msg = "There are no cancelled bookings by this user.";
        }
        public override string Message => msg;
    }
}
