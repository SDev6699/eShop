using OrderMicroservice.Domain.Entities;

namespace OrderMicroservice.Domain.Repositories
{
    public interface IOrderRepository
    {
        // Admin: Get all orders (paginated, sorted by OrderDate desc)
        Task<IEnumerable<Order>> GetAllOrdersAsync(int pageNumber, int pageSize);

        // Customer: Get own order history
        Task<IEnumerable<Order>> CheckOrderHistoryAsync(int customerId);

        // Single order lookup
        Task<Order> GetOrderAsync(int orderId);

        // Add & Update
        Task AddOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
    }
}