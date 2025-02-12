using OrderMicroservice.Application.DTOs;
using OrderMicroservice.Application.Interfaces;
using OrderMicroservice.Domain.Entities;
using OrderMicroservice.Domain.Repositories;

namespace OrderMicroservice.Application.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _cartRepository;
        
        public ShoppingCartService(IShoppingCartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        
        public async Task<ShoppingCartDto> GetShoppingCartByCustomerId(int customerId)
        {
            var cart = await _cartRepository.GetShoppingCartByCustomerIdAsync(customerId);
            if (cart == null)
                return null;
            
            return new ShoppingCartDto
            {
                Id = cart.Id,
                CustomerId = cart.CustomerId
            };
        }
        
        public async Task SaveShoppingCart(ShoppingCartDto dto)
        {
            var cart = new ShoppingCart
            {
                Id = dto.Id,
                CustomerId = dto.CustomerId
            };
            await _cartRepository.SaveShoppingCartAsync(cart);
        }
        
        public async Task DeleteShoppingCart(int cartId)
        {
            await _cartRepository.DeleteShoppingCartAsync(cartId);
        }
    }
}