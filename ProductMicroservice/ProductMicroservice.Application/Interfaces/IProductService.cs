using ProductMicroservice.Application.DTOs;

namespace ProductMicroservice.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetListAsync();
        Task<ProductDto> GetProductByIdAsync(int id);
        Task SaveProductAsync(ProductDto dto);
        Task UpdateProductAsync(ProductDto dto);
        Task InactiveProductAsync(int id);
        Task<IEnumerable<ProductDto>> GetProductByCategoryIdAsync(int categoryId);
        Task<IEnumerable<ProductDto>> GetProductByNameAsync(string name);
        Task DeleteProductAsync(int id);
    }
}