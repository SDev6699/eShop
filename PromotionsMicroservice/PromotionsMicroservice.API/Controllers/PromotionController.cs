using Microsoft.AspNetCore.Mvc;
using PromotionsMicroservice.Application.DTOs;
using PromotionsMicroservice.Application.Interfaces;

namespace PromotionsMicroservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionService _promotionService;

        public PromotionController(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        // GET /api/Promotion
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var promotions = await _promotionService.GetAllPromotionsAsync();
            return Ok(promotions);
        }

        // POST /api/Promotion
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PromotionRequestModel model)
        {
            await _promotionService.AddPromotionAsync(model);
            return Ok("Promotion created.");
        }

        // PUT /api/Promotion
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PromotionRequestModel model)
        {
            await _promotionService.UpdatePromotionAsync(model);
            return Ok("Promotion updated.");
        }

        // GET /api/Promotion/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var promo = await _promotionService.GetPromotionByIdAsync(id);
            if (promo == null) return NotFound();
            return Ok(promo);
        }

        // DELETE /api/Promotion/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _promotionService.DeletePromotionAsync(id);
            return Ok("Promotion deleted.");
        }

        // GET /api/Promotion/promotionByProductName?productName=...
        [HttpGet("promotionByProductName")]
        public async Task<IActionResult> GetByProductName([FromQuery] string productName)
        {
            var promotions = await _promotionService.GetPromotionsByProductNameAsync(productName);
            return Ok(promotions);
        }

        // GET /api/Promotion/activePromotions
        [HttpGet("activePromotions")]
        public async Task<IActionResult> GetActivePromotions()
        {
            var activePromos = await _promotionService.GetActivePromotionsAsync();
            return Ok(activePromos);
        }
    }
}
