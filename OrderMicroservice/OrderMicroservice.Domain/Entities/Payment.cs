namespace OrderMicroservice.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public int PaymentTypeId { get; set; }
        public string Provider { get; set; }
        public string AccountNumber { get; set; }
        public DateTime Expiry { get; set; }
        public bool IsDefault { get; set; }

        // Navigation
        public PaymentType PaymentType { get; set; }
    }
}