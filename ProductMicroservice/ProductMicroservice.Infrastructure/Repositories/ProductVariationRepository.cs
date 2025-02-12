using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Domain.Entities;
using ProductMicroservice.Domain.Repositories;
using ProductMicroservice.Infrastructure.Data;

namespace ProductMicroservice.Infrastructure.Repositories
{
    public class ProductVariationRepository : IProductVariationRepository
    {
        private readonly ProductMicroserviceDbContext _context;

        public ProductVariationRepository(ProductMicroserviceDbContext context)
        {
            _context = context;
        }

        public async Task SaveProductVariationAsync(ProductVariation productVariation)
        {
            if (productVariation.Id == 0)
                _context.ProductVariations.Add(productVariation);
            else
                _context.ProductVariations.Update(productVariation);

            await _context.SaveChangesAsync();
        }

        public async Task<ProductVariation> GetProductVariationAsync(int productId)
        {
            return await _context.ProductVariations
                .FirstOrDefaultAsync(pv => pv.ProductId == productId);
        }
    }
}