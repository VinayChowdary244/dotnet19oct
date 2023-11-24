namespace BusTicketingWebApplication.Exceptions
{
    public class InvalidNoOfTicketsEnteredException:Exception
    {

        string msg = "";
        public InvalidNoOfTicketsEnteredException()
        {
            msg = "The no of tickets entered is invalid.";
        }
        public override string Message => msg;
    }
}
