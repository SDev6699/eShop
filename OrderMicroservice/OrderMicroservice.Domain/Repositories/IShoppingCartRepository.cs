using OrderMicroservice.Domain.Entities;

namespace OrderMicroservice.Domain.Repositories
{
    public interface IShoppingCartItemRepository
    {
        Task<ShoppingCartItem> GetItemByIdAsync(int itemId);
        Task SaveItemAsync(ShoppingCartItem item);
        Task DeleteItemAsync(int itemId);
    }
}