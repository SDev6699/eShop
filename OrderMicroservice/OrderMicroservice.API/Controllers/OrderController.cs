using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.Application.DTOs;
using OrderMicroservice.Application.Interfaces;

namespace OrderMicroservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET /api/Order/GetAllOrders?PageNumber=1&PageSize=10
        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var orders = await _orderService.GetAllOrdersAsync(pageNumber, pageSize);
            return Ok(orders);
        }

        // POST /api/Order/SaveOrder
        [HttpPost("SaveOrder")]
        public async Task<IActionResult> SaveOrder([FromBody] CreateOrderDto dto)
        {
            var orderId = await _orderService.SaveOrderAsync(dto);
            return Ok(new { OrderId = orderId });
        }

        // GET /api/Order/CheckOrderHistory?customerId=123
        [HttpGet("CheckOrderHistory")]
        public async Task<IActionResult> CheckOrderHistory([FromQuery] int customerId)
        {
            var orders = await _orderService.CheckOrderHistoryAsync(customerId);
            return Ok(orders);
        }

        // GET /api/Order/CheckOrderStatus?orderId=456
        [HttpGet("CheckOrderStatus")]
        public async Task<IActionResult> CheckOrderStatus([FromQuery] int orderId)
        {
            var status = await _orderService.CheckOrderStatusAsync(orderId);
            return Ok(status);
        }

        // PUT /api/Order/CancelOrder?orderId=456
        [HttpPut("CancelOrder")]
        public async Task<IActionResult> CancelOrder([FromQuery] int orderId)
        {
            await _orderService.CancelOrderAsync(orderId);
            return Ok("Order cancelled (if it was still pending).");
        }

        // PUT /api/Order/OrderCompleted?orderId=456
        [HttpPut("OrderCompleted")]
        public async Task<IActionResult> OrderCompleted([FromQuery] int orderId)
        {
            await _orderService.OrderCompletedAsync(orderId);
            return Ok("Order completed (if it was still pending).");
        }
        
        // PUT /api/Order/UpdateOrder
        [HttpPut("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderDto dto)
        {
            await _orderService.UpdateOrderAsync(dto);
            return Ok("Order updated successfully.");
        }
    }
}
