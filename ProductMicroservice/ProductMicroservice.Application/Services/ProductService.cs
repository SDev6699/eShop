using ProductMicroservice.Application.DTOs;
using ProductMicroservice.Application.Interfaces;
using ProductMicroservice.Domain.Entities;
using ProductMicroservice.Domain.Repositories;

namespace ProductMicroservice.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetListAsync()
        {
            var products = await _productRepository.GetListAsync();
            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                CategoryId = p.CategoryId,
                Price = p.Price,
                Qty = p.Qty,
                ProductImage = p.ProductImage,
                SKU = p.SKU,
                IsActive = p.IsActive
            });
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var p = await _productRepository.GetProductByIdAsync(id);
            if (p == null) return null;

            return new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                CategoryId = p.CategoryId,
                Price = p.Price,
                Qty = p.Qty,
                ProductImage = p.ProductImage,
                SKU = p.SKU,
                IsActive = p.IsActive
            };
        }

        public async Task SaveProductAsync(ProductDto dto)
        {
            var product = new Product
            {
                Id = dto.Id, // 0 if new
                Name = dto.Name,
                Description = dto.Description,
                CategoryId = dto.CategoryId,
                Price = dto.Price,
                Qty = dto.Qty,
                ProductImage = dto.ProductImage,
                SKU = dto.SKU,
                IsActive = dto.IsActive
            };
            await _productRepository.SaveProductAsync(product);
        }

        public async Task UpdateProductAsync(ProductDto dto)
        {
            var product = new Product
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                CategoryId = dto.CategoryId,
                Price = dto.Price,
                Qty = dto.Qty,
                ProductImage = dto.ProductImage,
                SKU = dto.SKU,
                IsActive = dto.IsActive
            };
            await _productRepository.UpdateProductAsync(product);
        }

        public async Task InactiveProductAsync(int id)
        {
            await _productRepository.InactiveProductAsync(id);
        }

        public async Task<IEnumerable<ProductDto>> GetProductByCategoryIdAsync(int categoryId)
        {
            var products = await _productRepository.GetProductByCategoryIdAsync(categoryId);
            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                CategoryId = p.CategoryId,
                Price = p.Price,
                Qty = p.Qty,
                ProductImage = p.ProductImage,
                SKU = p.SKU,
                IsActive = p.IsActive
            });
        }

        public async Task<IEnumerable<ProductDto>> GetProductByNameAsync(string name)
        {
            var products = await _productRepository.GetProductByNameAsync(name);
            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                CategoryId = p.CategoryId,
                Price = p.Price,
                Qty = p.Qty,
                ProductImage = p.ProductImage,
                SKU = p.SKU,
                IsActive = p.IsActive
            });
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteProductAsync(id);
        }
    }
}
