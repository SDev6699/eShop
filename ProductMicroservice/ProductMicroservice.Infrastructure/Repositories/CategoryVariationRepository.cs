using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Domain.Entities;
using ProductMicroservice.Domain.Repositories;
using ProductMicroservice.Infrastructure.Data;

namespace ProductMicroservice.Infrastructure.Repositories
{
    public class CategoryVariationRepository : ICategoryVariationRepository
    {
        private readonly ProductMicroserviceDbContext _context;

        public CategoryVariationRepository(ProductMicroserviceDbContext context)
        {
            _context = context;
        }

        public async Task SaveCategoryVariationAsync(CategoryVariation catVar)
        {
            if (catVar.Id == 0)
                _context.CategoryVariations.Add(catVar);
            else
                _context.CategoryVariations.Update(catVar);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryVariation>> GetAllAsync()
        {
            return await _context.CategoryVariations.ToListAsync();
        }

        public async Task<CategoryVariation> GetByIdAsync(int id)
        {
            return await _context.CategoryVariations.FindAsync(id);
        }

        public async Task<IEnumerable<CategoryVariation>> GetByCategoryIdAsync(int categoryId)
        {
            return await _context.CategoryVariations
                .Where(cv => cv.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task DeleteCategoryVariationAsync(int id)
        {
            var catVar = await _context.CategoryVariations.FindAsync(id);
            if (catVar != null)
            {
                _context.CategoryVariations.Remove(catVar);
                await _context.SaveChangesAsync();
            }
        }
    }
}