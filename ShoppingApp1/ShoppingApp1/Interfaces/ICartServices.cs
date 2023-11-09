using ShoppingApp1.Models.DTOs;

namespace ShoppingApp1.Interfaces
{
    public interface ICartService
    {
        bool AddToCart(CartDTO cartDTO);
        bool RemoveFromCart(CartDTO cartDTO);
    }
}
