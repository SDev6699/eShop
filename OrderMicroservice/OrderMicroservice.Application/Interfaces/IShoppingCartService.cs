using OrderMicroservice.Application.DTOs;

namespace OrderMicroservice.Application.Interfaces
{
    public interface IShoppingCartService
    {
        Task<ShoppingCartDto> GetShoppingCartByCustomerId(int customerId);
        Task SaveShoppingCart(ShoppingCartDto dto);
        Task DeleteShoppingCart(int cartId);
    }
}