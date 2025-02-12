using ProductMicroservice.Application.DTOs;
using ProductMicroservice.Application.Interfaces;
using ProductMicroservice.Domain.Entities;
using ProductMicroservice.Domain.Repositories;

namespace ProductMicroservice.Application.Services
{
    public class ProductVariationService : IProductVariationService
    {
        private readonly IProductVariationRepository _productVariationRepo;

        public ProductVariationService(IProductVariationRepository productVariationRepo)
        {
            _productVariationRepo = productVariationRepo;
        }

        public async Task SaveProductVariationAsync(ProductVariationDto dto)
        {
            var pv = new ProductVariation
            {
                Id = dto.Id,
                ProductId = dto.ProductId
            };
            await _productVariationRepo.SaveProductVariationAsync(pv);
        }

        public async Task<ProductVariationDto> GetProductVariationAsync(int productId)
        {
            var pv = await _productVariationRepo.GetProductVariationAsync(productId);
            if (pv == null) return null;

            return new ProductVariationDto
            {
                Id = pv.Id,
                ProductId = pv.ProductId
            };
        }
    }
}