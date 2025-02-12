using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.Application.DTOs;
using OrderMicroservice.Application.Interfaces;

namespace OrderMicroservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // GET /api/Payment/GetPaymentByCustomerId?customerId=123
        [HttpGet("GetPaymentByCustomerId")]
        public async Task<IActionResult> GetPaymentByCustomerId([FromQuery] int customerId)
        {
            var payments = await _paymentService.GetPaymentsByCustomerId(customerId);
            return Ok(payments);
        }

        // POST /api/Payment/SavePayment
        [HttpPost("SavePayment")]
        public async Task<IActionResult> SavePayment([FromBody] PaymentDto dto)
        {
            await _paymentService.SavePayment(dto);
            return Ok("Payment saved successfully.");
        }

        // DELETE /api/Payment/DeletePayment?paymentId=999
        [HttpDelete("DeletePayment")]
        public async Task<IActionResult> DeletePayment([FromQuery] int paymentId)
        {
            await _paymentService.DeletePayment(paymentId);
            return Ok("Payment deleted successfully.");
        }
        
        // PUT /api/Payment/UpdatePayment
        [HttpPut("UpdatePayment")]
        public async Task<IActionResult> UpdatePayment([FromBody] PaymentDto dto)
        {
            await _paymentService.UpdatePaymentAsync(dto);
            return Ok("Payment updated successfully.");
        }
    }
}