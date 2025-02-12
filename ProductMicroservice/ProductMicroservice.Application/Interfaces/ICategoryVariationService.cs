using ProductMicroservice.Application.DTOs;

namespace ProductMicroservice.Application.Interfaces
{
    public interface ICategoryVariationService
    {
        Task SaveCategoryVariationAsync(CategoryVariationDto dto);
        Task<IEnumerable<CategoryVariationDto>> GetAllAsync();
        Task<CategoryVariationDto> GetByIdAsync(int id);
        Task<IEnumerable<CategoryVariationDto>> GetByCategoryIdAsync(int categoryId);
        Task DeleteCategoryVariationAsync(int id);
    }
}