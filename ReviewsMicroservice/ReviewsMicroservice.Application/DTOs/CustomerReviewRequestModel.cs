namespace ReviewsMicroservice.Application.DTOs
{
    public class CustomerReviewRequestModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int RatingValue { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        public string Status { get; set; } // "Pending", "Approved", "Rejected"
    }
}