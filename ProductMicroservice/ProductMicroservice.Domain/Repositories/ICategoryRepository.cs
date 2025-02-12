using ProductMicroservice.Domain.Entities;

namespace ProductMicroservice.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task SaveCategoryAsync(Category category);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<IEnumerable<Category>> GetCategoryByParentCategoryIdAsync(int parentId);
        Task DeleteCategoryAsync(int id);
    }
}