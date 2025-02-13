namespace ShippingMicroservice.Application.DTOs
{
    public class ShipperRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ContactPerson { get; set; }
    }
}