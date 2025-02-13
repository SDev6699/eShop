namespace PromotionsMicroservice.Application.DTOs
{
    public class PromotionRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Discount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // If needed, you can include details (like a list of ProductCategoryId/Name)
        // But for simplicity, let's just match your Swagger schema.
    }
}