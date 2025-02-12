using ProductMicroservice.Application.DTOs;
using ProductMicroservice.Application.Interfaces;
using ProductMicroservice.Domain.Entities;
using ProductMicroservice.Domain.Repositories;

namespace ProductMicroservice.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task SaveCategoryAsync(CategoryDto dto)
        {
            var category = new Category
            {
                Id = dto.Id,
                Name = dto.Name,
                ParentCategoryId = dto.ParentCategoryId
            };
            await _categoryRepository.SaveCategoryAsync(category);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            return categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                ParentCategoryId = c.ParentCategoryId
            });
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            var cat = await _categoryRepository.GetCategoryByIdAsync(id);
            if (cat == null) return null;

            return new CategoryDto
            {
                Id = cat.Id,
                Name = cat.Name,
                ParentCategoryId = cat.ParentCategoryId
            };
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoryByParentCategoryIdAsync(int parentId)
        {
            var cats = await _categoryRepository.GetCategoryByParentCategoryIdAsync(parentId);
            return cats.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                ParentCategoryId = c.ParentCategoryId
            });
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);
        }
    }
}
