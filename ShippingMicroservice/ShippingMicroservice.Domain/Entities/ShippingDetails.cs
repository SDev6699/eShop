namespace ShippingMicroservice.Domain.Entities
{
    public class ShippingDetails
    {
        public int Id { get; set; }
        public int OrderId { get; set; }      // Link to your Order microservice
        public int ShipperId { get; set; }
        public string ShippingStatus { get; set; }
        public string TrackingNumber { get; set; }

        // Navigation
        public Shipper Shipper { get; set; }
    }
}