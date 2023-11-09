using Microsoft.AspNetCore.Mvc;
using ShoppingApp1.Interfaces;
using ShoppingApp1.Models.DTOs;

namespace ShoppingApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpPost]
        public IActionResult AddToCart(CartDTO cartDTO)
        {
            var result = _cartService.AddToCart(cartDTO);
            if (result)
                return Ok(cartDTO);
            return BadRequest("Could not add item to cart");
        }
    }
}
