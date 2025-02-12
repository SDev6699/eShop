using ProductMicroservice.Domain.Entities;

namespace ProductMicroservice.Domain.Repositories
{
    public interface IVariationValueRepository
    {
        Task SaveVariationValueAsync(VariationValue value);
        Task<VariationValue> GetVariationValueAsync(int id);
    }
}