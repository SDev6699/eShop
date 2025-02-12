namespace ProductMicroservice.Application.DTOs
{
    public class CategoryVariationDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string VariationName { get; set; }
    }
}