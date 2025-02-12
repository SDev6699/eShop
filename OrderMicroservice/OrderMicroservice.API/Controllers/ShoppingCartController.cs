using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.Application.DTOs;
using OrderMicroservice.Application.Interfaces;

namespace OrderMicroservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _cartService;

        public ShoppingCartController(IShoppingCartService cartService)
        {
            _cartService = cartService;
        }

        // GET /api/ShoppingCart/GetShoppingCartByCustomerId?customerId=123
        [HttpGet("GetShoppingCartByCustomerId")]
        public async Task<IActionResult> GetShoppingCartByCustomerId([FromQuery] int customerId)
        {
            var cart = await _cartService.GetShoppingCartByCustomerId(customerId);
            if (cart == null) return NotFound("No cart found for this customer.");
            return Ok(cart);
        }

        // POST /api/ShoppingCart/SaveShoppingCart
        [HttpPost("SaveShoppingCart")]
        public async Task<IActionResult> SaveShoppingCart([FromBody] ShoppingCartDto dto)
        {
            await _cartService.SaveShoppingCart(dto);
            return Ok("Shopping cart saved.");
        }

        // DELETE /api/ShoppingCart/DeleteShoppingCart?cartId=111
        [HttpDelete("DeleteShoppingCart")]
        public async Task<IActionResult> DeleteShoppingCart([FromQuery] int cartId)
        {
            await _cartService.DeleteShoppingCart(cartId);
            return Ok("Shopping cart deleted.");
        }
    }
}