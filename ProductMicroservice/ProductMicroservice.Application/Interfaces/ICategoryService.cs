using ProductMicroservice.Application.DTOs;

namespace ProductMicroservice.Application.Interfaces
{
    public interface ICategoryService
    {
        Task SaveCategoryAsync(CategoryDto dto);
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task<IEnumerable<CategoryDto>> GetCategoryByParentCategoryIdAsync(int parentId);
        Task DeleteCategoryAsync(int id);
    }
}