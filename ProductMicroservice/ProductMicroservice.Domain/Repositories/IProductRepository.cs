using ProductMicroservice.Domain.Entities;

namespace ProductMicroservice.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetListAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task SaveProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task InactiveProductAsync(int id);
        Task<IEnumerable<Product>> GetProductByCategoryIdAsync(int categoryId);
        Task<IEnumerable<Product>> GetProductByNameAsync(string name);
        Task DeleteProductAsync(int id);
    }
}