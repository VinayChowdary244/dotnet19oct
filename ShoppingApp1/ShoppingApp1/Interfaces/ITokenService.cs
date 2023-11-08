using ShoppingApp1.Models.DTOs;

namespace ShoppingApp1.Interfaces
{
    public interface ITokenService
    {
        string GetToken(UserDTO user);
    }
}
