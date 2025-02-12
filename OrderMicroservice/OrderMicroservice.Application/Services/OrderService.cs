using System.Linq;
using OrderMicroservice.Application.DTOs;
using OrderMicroservice.Application.Interfaces;
using OrderMicroservice.Domain.Entities;
using OrderMicroservice.Domain.Enums;
using OrderMicroservice.Domain.Repositories;

namespace OrderMicroservice.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync(int pageNumber, int pageSize)
        {
            return await _orderRepository.GetAllOrdersAsync(pageNumber, pageSize);
        }

        public async Task<int> SaveOrderAsync(CreateOrderDto dto)
        {
            var order = new Order
            {
                CustomerId = dto.CustomerId,
                OrderDate = DateTime.UtcNow,
                BillAmount = dto.BillAmount,
                OrderStatus = OrderStatus.Pending,
                PaymentMethodId = dto.PaymentMethodId,
                PaymentName = dto.PaymentName,
                ShippingAddress = dto.ShippingAddress,
                ShippingMethod = dto.ShippingMethod,
                OrderItems = dto.Items?.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    ProductName = i.ProductName,
                    Qty = i.Qty,
                    Price = i.Price,
                    Discount = i.Discount
                }).ToList()
            };

            await _orderRepository.AddOrderAsync(order);
            return order.Id;
        }

        public async Task<IEnumerable<Order>> CheckOrderHistoryAsync(int customerId)
        {
            return await _orderRepository.CheckOrderHistoryAsync(customerId);
        }

        public async Task<string> CheckOrderStatusAsync(int orderId)
        {
            var order = await _orderRepository.GetOrderAsync(orderId);
            return order?.OrderStatus.ToString() ?? "NotFound";
        }

        public async Task CancelOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetOrderAsync(orderId);
            if (order != null && order.OrderStatus == OrderStatus.Pending)
            {
                order.OrderStatus = OrderStatus.Cancelled;
                await _orderRepository.UpdateOrderAsync(order);
            }
        }

        public async Task OrderCompletedAsync(int orderId)
        {
            var order = await _orderRepository.GetOrderAsync(orderId);
            if (order != null && order.OrderStatus == OrderStatus.Pending)
            {
                order.OrderStatus = OrderStatus.Completed;
                await _orderRepository.UpdateOrderAsync(order);
            }
        }
        
        public async Task UpdateOrderAsync(UpdateOrderDto dto)
        {
            var order = await _orderRepository.GetOrderAsync(dto.Id);
            if (order == null)
                throw new Exception("Order not found.");

            // Update fields based on the DTO
            order.BillAmount = dto.BillAmount;
            order.PaymentMethodId = dto.PaymentMethodId;
            order.PaymentName = dto.PaymentName;
            order.ShippingAddress = dto.ShippingAddress;
            order.ShippingMethod = dto.ShippingMethod;
            
            if (dto.Items != null)
            {
                // For simplicity, replace all order items with new ones.
                order.OrderItems = dto.Items.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    ProductName = i.ProductName,
                    Qty = i.Qty,
                    Price = i.Price,
                    Discount = i.Discount
                }).ToList();
            }
            await _orderRepository.UpdateOrderAsync(order);
        }
    }
}
