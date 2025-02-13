namespace PromotionsMicroservice.Domain.Entities
{
    public class PromotionDetails
    {
        public int Id { get; set; }
        public int PromotionId { get; set; }
        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }

        // Navigation
        public Promotion Promotion { get; set; }
    }
}