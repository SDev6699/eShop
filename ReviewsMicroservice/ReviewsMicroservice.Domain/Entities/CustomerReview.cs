namespace ReviewsMicroservice.Domain.Entities
{
    public class CustomerReview
    {
        public int Id { get; set; }
        
        // Basic fields from your ER diagram
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int RatingValue { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        
        // For admin approval (Pending, Approved, Rejected, etc.)
        public string Status { get; set; } = "Pending";
    }
}