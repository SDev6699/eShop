using OrderMicroservice.Domain.Enums;

namespace OrderMicroservice.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal BillAmount { get; set; }
        public OrderStatus OrderStatus { get; set; }

        // Payment & Shipping
        public string PaymentMethodId { get; set; }
        public string PaymentName { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingMethod { get; set; }

        // Navigation
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}