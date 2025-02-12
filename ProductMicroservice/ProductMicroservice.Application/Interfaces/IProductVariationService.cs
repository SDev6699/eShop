using ProductMicroservice.Application.DTOs;

namespace ProductMicroservice.Application.Interfaces
{
    public interface IProductVariationService
    {
        Task SaveProductVariationAsync(ProductVariationDto dto);
        Task<ProductVariationDto> GetProductVariationAsync(int productId);
    }
}