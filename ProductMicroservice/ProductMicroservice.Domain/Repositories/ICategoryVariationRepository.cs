using ProductMicroservice.Domain.Entities;

namespace ProductMicroservice.Domain.Repositories
{
    public interface ICategoryVariationRepository
    {
        Task SaveCategoryVariationAsync(CategoryVariation catVar);
        Task<IEnumerable<CategoryVariation>> GetAllAsync();
        Task<CategoryVariation> GetByIdAsync(int id);
        Task<IEnumerable<CategoryVariation>> GetByCategoryIdAsync(int categoryId);
        Task DeleteCategoryVariationAsync(int id);
    }
}