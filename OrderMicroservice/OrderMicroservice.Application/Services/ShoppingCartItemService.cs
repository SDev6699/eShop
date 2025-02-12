using OrderMicroservice.Application.DTOs;
using OrderMicroservice.Application.Interfaces;
using OrderMicroservice.Domain.Entities;
using OrderMicroservice.Domain.Repositories;

namespace OrderMicroservice.Application.Services
{
    public class ShoppingCartItemService : IShoppingCartItemService
    {
        private readonly IShoppingCartItemRepository _itemRepository;
        
        public ShoppingCartItemService(IShoppingCartItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        
        public async Task<ShoppingCartItemDto> GetItemById(int itemId)
        {
            var item = await _itemRepository.GetItemByIdAsync(itemId);
            if (item == null)
                return null;
            
            return new ShoppingCartItemDto
            {
                Id = item.Id,
                ShoppingCartId = item.ShoppingCartId,
                ProductId = item.ProductId,
                ProductName = item.ProductName,
                Qty = item.Qty,
                Price = item.Price,
                Discount = item.Discount
            };
        }
        
        public async Task SaveItem(ShoppingCartItemDto dto)
        {
            var item = new ShoppingCartItem
            {
                Id = dto.Id,
                ShoppingCartId = dto.ShoppingCartId,
                ProductId = dto.ProductId,
                ProductName = dto.ProductName,
                Qty = dto.Qty,
                Price = dto.Price,
                Discount = dto.Discount
            };
            await _itemRepository.SaveItemAsync(item);
        }
        
        public async Task DeleteItem(int itemId)
        {
            await _itemRepository.DeleteItemAsync(itemId);
        }
    }
}