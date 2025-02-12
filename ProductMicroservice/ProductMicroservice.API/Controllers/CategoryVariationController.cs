using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Application.DTOs;
using ProductMicroservice.Application.Interfaces;

namespace ProductMicroservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryVariationController : ControllerBase
    {
        private readonly ICategoryVariationService _catVarService;

        public CategoryVariationController(ICategoryVariationService catVarService)
        {
            _catVarService = catVarService;
        }

        // POST /api/CategoryVariation/Save
        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] CategoryVariationDto dto)
        {
            await _catVarService.SaveCategoryVariationAsync(dto);
            return Ok("Category Variation saved.");
        }

        // GET /api/CategoryVariation/GetAll
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _catVarService.GetAllAsync();
            return Ok(list);
        }

        // GET /api/CategoryVariation/GetCategoryVariationById?id=123
        [HttpGet("GetCategoryVariationById")]
        public async Task<IActionResult> GetCategoryVariationById([FromQuery] int id)
        {
            var cv = await _catVarService.GetByIdAsync(id);
            if (cv == null) return NotFound();
            return Ok(cv);
        }

        // GET /api/CategoryVariation/GetCategoryVariationByCategoryId?categoryId=1
        [HttpGet("GetCategoryVariationByCategoryId")]
        public async Task<IActionResult> GetCategoryVariationByCategoryId([FromQuery] int categoryId)
        {
            var list = await _catVarService.GetByCategoryIdAsync(categoryId);
            return Ok(list);
        }

        // DELETE /api/CategoryVariation/Delete?id=123
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _catVarService.DeleteCategoryVariationAsync(id);
            return Ok("Category Variation deleted.");
        }
    }
}
