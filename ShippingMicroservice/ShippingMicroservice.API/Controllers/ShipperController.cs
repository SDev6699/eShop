using Microsoft.AspNetCore.Mvc;
using ShippingMicroservice.Application.DTOs;
using ShippingMicroservice.Application.Interfaces;

namespace ShippingMicroservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShipperController : ControllerBase
    {
        private readonly IShipperService _shipperService;

        public ShipperController(IShipperService shipperService)
        {
            _shipperService = shipperService;
        }

        // GET /api/Shipper
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var shippers = await _shipperService.GetAllShippersAsync();
            return Ok(shippers);
        }

        // POST /api/Shipper
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ShipperRequestModel model)
        {
            await _shipperService.AddShipperAsync(model);
            return Ok("Shipper created.");
        }

        // PUT /api/Shipper
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ShipperRequestModel model)
        {
            await _shipperService.UpdateShipperAsync(model);
            return Ok("Shipper updated.");
        }

        // DELETE /api/Shipper/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _shipperService.DeleteShipperAsync(id);
            return Ok("Shipper deleted.");
        }

        // GET /api/Shipper/region/{region}
        [HttpGet("region/{region}")]
        public async Task<IActionResult> GetByRegion([FromRoute] string region)
        {
            var shippers = await _shipperService.GetShippersByRegionAsync(region);
            return Ok(shippers);
        }
    }
}