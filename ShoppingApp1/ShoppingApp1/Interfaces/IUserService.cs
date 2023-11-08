using ShoppingApp1.Models.DTOs;

namespace ShoppingApp1.Interfaces
{
    public interface IUserService
    {
        UserDTO Login(UserDTO userDTO);
        UserDTO Register(UserDTO userDTO);
    }
}
