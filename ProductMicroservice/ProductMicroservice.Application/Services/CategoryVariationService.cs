using ProductMicroservice.Application.DTOs;
using ProductMicroservice.Application.Interfaces;
using ProductMicroservice.Domain.Entities;
using ProductMicroservice.Domain.Repositories;

namespace ProductMicroservice.Application.Services
{
    public class CategoryVariationService : ICategoryVariationService
    {
        private readonly ICategoryVariationRepository _catVarRepository;

        public CategoryVariationService(ICategoryVariationRepository catVarRepository)
        {
            _catVarRepository = catVarRepository;
        }

        public async Task SaveCategoryVariationAsync(CategoryVariationDto dto)
        {
            var catVar = new CategoryVariation
            {
                Id = dto.Id,
                CategoryId = dto.CategoryId,
                VariationName = dto.VariationName
            };
            await _catVarRepository.SaveCategoryVariationAsync(catVar);
        }

        public async Task<IEnumerable<CategoryVariationDto>> GetAllAsync()
        {
            var list = await _catVarRepository.GetAllAsync();
            return list.Select(v => new CategoryVariationDto
            {
                Id = v.Id,
                CategoryId = v.CategoryId,
                VariationName = v.VariationName
            });
        }

        public async Task<CategoryVariationDto> GetByIdAsync(int id)
        {
            var catVar = await _catVarRepository.GetByIdAsync(id);
            if (catVar == null) return null;

            return new CategoryVariationDto
            {
                Id = catVar.Id,
                CategoryId = catVar.CategoryId,
                VariationName = catVar.VariationName
            };
        }

        public async Task<IEnumerable<CategoryVariationDto>> GetByCategoryIdAsync(int categoryId)
        {
            var list = await _catVarRepository.GetByCategoryIdAsync(categoryId);
            return list.Select(v => new CategoryVariationDto
            {
                Id = v.Id,
                CategoryId = v.CategoryId,
                VariationName = v.VariationName
            });
        }

        public async Task DeleteCategoryVariationAsync(int id)
        {
            await _catVarRepository.DeleteCategoryVariationAsync(id);
        }
    }
}
