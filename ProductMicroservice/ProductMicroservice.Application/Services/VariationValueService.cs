using ProductMicroservice.Application.DTOs;
using ProductMicroservice.Application.Interfaces;
using ProductMicroservice.Domain.Entities;
using ProductMicroservice.Domain.Repositories;

namespace ProductMicroservice.Application.Services
{
    public class VariationValueService : IVariationValueService
    {
        private readonly IVariationValueRepository _variationValueRepo;

        public VariationValueService(IVariationValueRepository variationValueRepo)
        {
            _variationValueRepo = variationValueRepo;
        }

        public async Task SaveVariationValueAsync(VariationValueDto dto)
        {
            var vv = new VariationValue
            {
                Id = dto.Id,
                CategoryVariationId = dto.CategoryVariationId,
                Value = dto.Value
            };
            await _variationValueRepo.SaveVariationValueAsync(vv);
        }

        public async Task<VariationValueDto> GetVariationValueAsync(int id)
        {
            var vv = await _variationValueRepo.GetVariationValueAsync(id);
            if (vv == null) return null;

            return new VariationValueDto
            {
                Id = vv.Id,
                CategoryVariationId = vv.CategoryVariationId,
                Value = vv.Value
            };
        }
    }
}