using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Application.DTOs;
using ProductMicroservice.Application.Interfaces;

namespace ProductMicroservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // POST /api/Category/SaveCategory
        [HttpPost("SaveCategory")]
        public async Task<IActionResult> SaveCategory([FromBody] CategoryDto dto)
        {
            await _categoryService.SaveCategoryAsync(dto);
            return Ok("Category saved.");
        }

        // GET /api/Category/GetAllCategory
        [HttpGet("GetAllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        // GET /api/Category/GetCategoryById?id=123
        [HttpGet("GetCategoryById")]
        public async Task<IActionResult> GetCategoryById([FromQuery] int id)
        {
            var cat = await _categoryService.GetCategoryByIdAsync(id);
            if (cat == null) return NotFound();
            return Ok(cat);
        }

        // GET /api/Category/GetCategoryByParentCategoryId?parentId=1
        [HttpGet("GetCategoryByParentCategoryId")]
        public async Task<IActionResult> GetCategoryByParentCategoryId([FromQuery] int parentId)
        {
            var cats = await _categoryService.GetCategoryByParentCategoryIdAsync(parentId);
            return Ok(cats);
        }

        // DELETE /api/Category/Delete?id=123
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok("Category deleted.");
        }
    }
}
