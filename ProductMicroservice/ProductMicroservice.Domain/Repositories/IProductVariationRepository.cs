using ProductMicroservice.Domain.Entities;

namespace ProductMicroservice.Domain.Repositories
{
    public interface IProductVariationRepository
    {
        Task SaveProductVariationAsync(ProductVariation productVariation);
        Task<ProductVariation> GetProductVariationAsync(int productId);
    }
}