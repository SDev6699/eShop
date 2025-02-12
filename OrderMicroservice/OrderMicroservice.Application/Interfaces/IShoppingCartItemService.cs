using OrderMicroservice.Application.DTOs;

namespace OrderMicroservice.Application.Interfaces
{
    public interface IShoppingCartItemService
    {
        Task<ShoppingCartItemDto> GetItemById(int itemId);
        Task SaveItem(ShoppingCartItemDto dto);
        Task DeleteItem(int itemId);
    }
}