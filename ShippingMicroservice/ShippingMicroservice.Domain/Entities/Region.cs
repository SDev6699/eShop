namespace ShippingMicroservice.Domain.Entities
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation
        public ICollection<ShipperRegion> ShipperRegions { get; set; }
    }
}