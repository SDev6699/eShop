using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Application.DTOs;
using ProductMicroservice.Application.Interfaces;

namespace ProductMicroservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductVariationController : ControllerBase
    {
        private readonly IProductVariationService _productVariationService;

        public ProductVariationController(IProductVariationService productVariationService)
        {
            _productVariationService = productVariationService;
        }

        // POST /api/ProductVariation/Save
        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] ProductVariationDto dto)
        {
            await _productVariationService.SaveProductVariationAsync(dto);
            return Ok("Product Variation saved.");
        }

        // GET /api/ProductVariation/GetProductVariation?productId=123
        [HttpGet("GetProductVariation")]
        public async Task<IActionResult> GetProductVariation([FromQuery] int productId)
        {
            var pv = await _productVariationService.GetProductVariationAsync(productId);
            if (pv == null) return NotFound();
            return Ok(pv);
        }
    }
}