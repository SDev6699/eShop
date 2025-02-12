using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Application.DTOs;
using ProductMicroservice.Application.Interfaces;

namespace ProductMicroservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VariationValueController : ControllerBase
    {
        private readonly IVariationValueService _variationValueService;

        public VariationValueController(IVariationValueService variationValueService)
        {
            _variationValueService = variationValueService;
        }

        // POST /api/VariationValue/Save
        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] VariationValueDto dto)
        {
            await _variationValueService.SaveVariationValueAsync(dto);
            return Ok("Variation Value saved.");
        }

        // GET /api/VariationValue/GetVariationValue?id=123
        [HttpGet("GetVariationValue")]
        public async Task<IActionResult> GetVariationValue([FromQuery] int id)
        {
            var vv = await _variationValueService.GetVariationValueAsync(id);
            if (vv == null) return NotFound();
            return Ok(vv);
        }
    }
}