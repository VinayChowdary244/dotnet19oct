using BusModelLibrary;
using BusTicketingWebApplication.Models;
using BusTicketingWebApplication.Models.DTOs;

namespace BusTicketingWebApplication.Interfaces
{
    public interface IUserService
    {
        UserDTO Login(UserDTO userDTO);
        UserDTO Register(UserDTO userDTO);
        List<Bus> BusSearch(BusSearchDTO busSearchDTO);
        UserDTO UpdateUser(UserDTO userDTO);
        BusDTO BookSeat(BusDTO busDTO);
        List<User> GetAllUsers();
        List<Booking> GetBookingHistory(UserIdDTO userIdDTO);
       
    }
}
