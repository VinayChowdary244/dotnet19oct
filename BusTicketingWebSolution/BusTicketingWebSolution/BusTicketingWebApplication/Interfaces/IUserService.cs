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
        UserUpdateDTO UpdateUser(UserUpdateDTO userUpdateDTO);
        BusDTO BookSeat(BusDTO busDTO);
        List<User> GetAllUsers();
        List<Booking> GetBookingHistory(UserNameDTO userNameDTO);
       
    }
}
