namespace BusTicketingWebApplication.Exceptions
{
    public class NoBookingsYetException:Exception
    {

        string msg = "";
        public NoBookingsYetException()
        {
            msg = "You havent booked anything yet.";
        }
        public override string Message => msg;
    }
}
