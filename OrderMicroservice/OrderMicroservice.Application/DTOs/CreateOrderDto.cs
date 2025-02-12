using System.Collections.Generic;

namespace OrderMicroservice.Application.DTOs
{
    public class CreateOrderDto
    {
        public int CustomerId { get; set; }
        public decimal BillAmount { get; set; }
        public string PaymentMethodId { get; set; }
        public string PaymentName { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingMethod { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }
}