using OrderMicroservice.Application.DTOs;
using OrderMicroservice.Domain.Entities;

namespace OrderMicroservice.Application.Interfaces
{
    public interface IOrderService
    {
        // Admin: Get all orders with pagination
        Task<IEnumerable<Order>> GetAllOrdersAsync(int pageNumber, int pageSize);

        // Save a new order
        Task<int> SaveOrderAsync(CreateOrderDto dto);

        // Customer: check own order history
        Task<IEnumerable<Order>> CheckOrderHistoryAsync(int customerId);

        // Check a single order's status
        Task<string> CheckOrderStatusAsync(int orderId);

        // Cancel an order
        Task CancelOrderAsync(int orderId);

        // Mark order completed
        Task OrderCompletedAsync(int orderId);
        
        // Update order
        Task UpdateOrderAsync(UpdateOrderDto dto);
    }
}