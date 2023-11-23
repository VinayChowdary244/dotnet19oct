namespace HotelBooking.Exceptions
{
    public class NoRoomsAvailableException : Exception
    {
        string message;
        public NoRoomsAvailableException()
        {
            message = "Sorry,No Rooms are available ";
        }
        public override string Message => message;
    }
}
