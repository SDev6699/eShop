using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Application.DTOs;
using ProductMicroservice.Application.Interfaces;

namespace ProductMicroservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET /api/Product/GetListProducts
        [HttpGet("GetListProducts")]
        public async Task<IActionResult> GetListProducts()
        {
            var products = await _productService.GetListAsync();
            return Ok(products);
        }

        // GET /api/Product/GetProductById?id=123
        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProductById([FromQuery] int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // POST /api/Product/Save
        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] ProductDto dto)
        {
            await _productService.SaveProductAsync(dto);
            return Ok("Product saved.");
        }

        // PUT /api/Product/Update
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] ProductDto dto)
        {
            await _productService.UpdateProductAsync(dto);
            return Ok("Product updated.");
        }

        // PUT /api/Product/Inactive?id=123
        [HttpPut("Inactive")]
        public async Task<IActionResult> Inactive([FromQuery] int id)
        {
            await _productService.InactiveProductAsync(id);
            return Ok("Product inactivated.");
        }

        // GET /api/Product/GetProductByCategoryId?categoryId=1
        [HttpGet("GetProductByCategoryId")]
        public async Task<IActionResult> GetProductByCategoryId([FromQuery] int categoryId)
        {
            var products = await _productService.GetProductByCategoryIdAsync(categoryId);
            return Ok(products);
        }

        // GET /api/Product/GetProductByName?name=abc
        [HttpGet("GetProductByName")]
        public async Task<IActionResult> GetProductByName([FromQuery] string name)
        {
            var products = await _productService.GetProductByNameAsync(name);
            return Ok(products);
        }

        // DELETE /api/Product/DeleteProduct?id=123
        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromQuery] int id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok("Product deleted.");
        }
    }
}
