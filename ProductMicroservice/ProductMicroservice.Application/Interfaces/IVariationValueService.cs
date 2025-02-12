using ProductMicroservice.Application.DTOs;

namespace ProductMicroservice.Application.Interfaces
{
    public interface IVariationValueService
    {
        Task SaveVariationValueAsync(VariationValueDto dto);
        Task<VariationValueDto> GetVariationValueAsync(int id);
    }
}