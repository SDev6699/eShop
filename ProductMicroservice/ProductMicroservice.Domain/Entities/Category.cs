namespace ProductMicroservice.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // If there's a parent category
        public int? ParentCategoryId { get; set; }

        // Navigation
        public ICollection<CategoryVariation> CategoryVariations { get; set; }
    }
}