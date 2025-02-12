using Microsoft.EntityFrameworkCore;
using OrderMicroservice.Domain.Entities;
using OrderMicroservice.Domain.Repositories;
using OrderMicroservice.Infrastructure.Data;

namespace OrderMicroservice.Infrastructure.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly OrderMicroserviceDbContext _context;

        public ShoppingCartRepository(OrderMicroserviceDbContext context)
        {
            _context = context;
        }

        public async Task<ShoppingCart> GetShoppingCartByCustomerIdAsync(int customerId)
        {
            return await _context.ShoppingCarts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }

        public async Task SaveShoppingCartAsync(ShoppingCart cart)
        {
            if (cart.Id == 0)
            {
                _context.ShoppingCarts.Add(cart);
            }
            else
            {
                _context.ShoppingCarts.Update(cart);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteShoppingCartAsync(int cartId)
        {
            var cart = await _context.ShoppingCarts.FindAsync(cartId);
            if (cart != null)
            {
                _context.ShoppingCarts.Remove(cart);
                await _context.SaveChangesAsync();
            }
        }
    }
}