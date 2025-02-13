namespace ShippingMicroservice.Domain.Entities
{
    public class Shipper
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ContactPerson { get; set; }

        // Navigation
        public ICollection<ShipperRegion> ShipperRegions { get; set; }
    }
}