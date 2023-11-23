namespace HotelBooking.Exceptions
{
    public class NoHotelAvailableException : Exception
    {
        string message;
        public NoHotelAvailableException()
        {
            message = "No Hotels are available for booking";
        }
        public override string Message => message;
    }
}
