namespace ProductMicroservice.Domain.Entities
{
    public class CategoryVariation
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string VariationName { get; set; }

        // Navigation
        public Category Category { get; set; }
        public ICollection<VariationValue> VariationValues { get; set; }
    }
}