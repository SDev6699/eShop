using OrderMicroservice.Domain.Entities;

namespace OrderMicroservice.Domain.Repositories
{
    public interface IShoppingCartRepository
    {
        Task<ShoppingCart> GetShoppingCartByCustomerIdAsync(int customerId);
        Task SaveShoppingCartAsync(ShoppingCart cart);
        Task DeleteShoppingCartAsync(int cartId);
    }
}