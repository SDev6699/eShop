using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.Application.DTOs;
using OrderMicroservice.Application.Interfaces;

namespace OrderMicroservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET /api/Customer/GetCustomerAddressByUserId?userId=xyz
        [HttpGet("GetCustomerAddressByUserId")]
        public async Task<IActionResult> GetCustomerAddressByUserId([FromQuery] string userId)
        {
            var address = await _customerService.GetCustomerAddressByUserId(userId);
            if (address == null)
                return NotFound("No address found for this user.");
            return Ok(address);
        }

        // POST /api/Customer/SaveCustomerAddress?userId=xyz
        [HttpPost("SaveCustomerAddress")]
        public async Task<IActionResult> SaveCustomerAddress([FromBody] AddressDto addressDto, [FromQuery] string userId)
        {
            await _customerService.SaveCustomerAddress(addressDto, userId);
            return Ok("Address saved successfully.");
        }
    }
}