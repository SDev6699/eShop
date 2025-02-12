using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.Application.DTOs;
using OrderMicroservice.Application.Interfaces;

namespace OrderMicroservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartItemController : ControllerBase
    {
        private readonly IShoppingCartItemService _itemService;

        public ShoppingCartItemController(IShoppingCartItemService itemService)
        {
            _itemService = itemService;
        }

        // GET /api/ShoppingCartItem/GetShoppingCartItemById?itemId=555
        [HttpGet("GetShoppingCartItemById")]
        public async Task<IActionResult> GetShoppingCartItemById([FromQuery] int itemId)
        {
            var item = await _itemService.GetItemById(itemId);
            if (item == null) return NotFound("Item not found.");
            return Ok(item);
        }

        // POST /api/ShoppingCartItem/SaveShoppingCartItem
        [HttpPost("SaveShoppingCartItem")]
        public async Task<IActionResult> SaveShoppingCartItem([FromBody] ShoppingCartItemDto dto)
        {
            await _itemService.SaveItem(dto);
            return Ok("Item saved.");
        }

        // DELETE /api/ShoppingCartItem/DeleteShoppingCartItemById?itemId=555
        [HttpDelete("DeleteShoppingCartItemById")]
        public async Task<IActionResult> DeleteShoppingCartItemById([FromQuery] int itemId)
        {
            await _itemService.DeleteItem(itemId);
            return Ok("Item deleted.");
        }
    }
}