using Microsoft.AspNetCore.Mvc;
using ReviewsMicroservice.Application.DTOs;
using ReviewsMicroservice.Application.Interfaces;

namespace ReviewsMicroservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerReviewController : ControllerBase
    {
        private readonly ICustomerReviewService _reviewService;

        public CustomerReviewController(ICustomerReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // GET /api/CustomerReview
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reviews = await _reviewService.GetAllAsync();
            return Ok(reviews);
        }
        
        // GET /api/CustomerReview/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var review = await _reviewService.GetByIdAsync(id);
            if (review == null) return NotFound();
            return Ok(review);
        }
        
        // GET /api/CustomerReview/year/{year}
        [HttpGet("year/{year}")]
        public async Task<IActionResult> GetByYear([FromRoute] int year)
        {
            var reviews = await _reviewService.GetByYearAsync(year);
            return Ok(reviews);
        }

        // POST /api/CustomerReview
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerReviewRequestModel model)
        {
            await _reviewService.AddAsync(model);
            return Ok("Review created (pending approval).");
        }

        // PUT /api/CustomerReview
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CustomerReviewRequestModel model)
        {
            await _reviewService.UpdateAsync(model);
            return Ok("Review updated.");
        }

        // DELETE /api/CustomerReview/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _reviewService.DeleteAsync(id);
            return Ok("Review deleted.");
        }

        // GET /api/CustomerReview/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserId([FromRoute] int userId)
        {
            var reviews = await _reviewService.GetByUserIdAsync(userId);
            return Ok(reviews);
        }

        // GET /api/CustomerReview/product/{productId}
        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProductId([FromRoute] int productId)
        {
            var reviews = await _reviewService.GetByProductIdAsync(productId);
            return Ok(reviews);
        }

        // PUT /api/CustomerReview/approve/{id}
        [HttpPut("approve/{id}")]
        public async Task<IActionResult> ApproveReview([FromRoute] int id)
        {
            await _reviewService.ApproveReviewAsync(id);
            return Ok("Review approved.");
        }

        // PUT /api/CustomerReview/reject/{id}
        [HttpPut("reject/{id}")]
        public async Task<IActionResult> RejectReview([FromRoute] int id)
        {
            await _reviewService.RejectReviewAsync(id);
            return Ok("Review rejected.");
        }
    }
}
