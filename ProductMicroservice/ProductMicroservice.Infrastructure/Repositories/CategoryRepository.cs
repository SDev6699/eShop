using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Domain.Entities;
using ProductMicroservice.Domain.Repositories;
using ProductMicroservice.Infrastructure.Data;

namespace ProductMicroservice.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductMicroserviceDbContext _context;

        public CategoryRepository(ProductMicroserviceDbContext context)
        {
            _context = context;
        }

        public async Task SaveCategoryAsync(Category category)
        {
            if (category.Id == 0)
                _context.Categories.Add(category);
            else
                _context.Categories.Update(category);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategoryByParentCategoryIdAsync(int parentId)
        {
            return await _context.Categories
                .Where(c => c.ParentCategoryId == parentId)
                .ToListAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var cat = await _context.Categories.FindAsync(id);
            if (cat != null)
            {
                _context.Categories.Remove(cat);
                await _context.SaveChangesAsync();
            }
        }
    }
}