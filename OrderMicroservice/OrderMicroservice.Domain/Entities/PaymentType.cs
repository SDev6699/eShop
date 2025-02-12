namespace OrderMicroservice.Domain.Entities
{
    public class PaymentType
    {
        public int Id { get; set; }
        public string Name { get; set; } // e.g. "Credit Card"

        // Navigation
        public ICollection<Payment> Payments { get; set; }
    }
}