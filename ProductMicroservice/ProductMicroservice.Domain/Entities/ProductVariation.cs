namespace ProductMicroservice.Domain.Entities
{
    public class ProductVariation
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        
        // Could hold additional fields if needed
        // e.g. "VariationTitle" or "CustomName"
        
        // Navigation
        public Product Product { get; set; }
        // Possibly a collection of VariationValues, if you want a direct link
    }
}