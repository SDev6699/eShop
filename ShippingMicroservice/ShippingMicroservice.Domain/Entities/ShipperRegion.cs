namespace ShippingMicroservice.Domain.Entities
{
    public class ShipperRegion
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public int ShipperId { get; set; }
        public bool Active { get; set; }

        // Navigation
        public Region Region { get; set; }
        public Shipper Shipper { get; set; }
    }
}