namespace ProductMicroservice.Domain.Entities
{
    public class VariationValue
    {
        public int Id { get; set; }
        public int CategoryVariationId { get; set; }
        public string Value { get; set; }

        // Navigation
        public CategoryVariation CategoryVariation { get; set; }
    }
}