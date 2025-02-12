using OrderMicroservice.Domain.Entities;
using OrderMicroservice.Domain.Repositories;
using OrderMicroservice.Infrastructure.Data;

namespace OrderMicroservice.Infrastructure.Repositories
{
    public class ShoppingCartItemRepository : IShoppingCartItemRepository
    {
        private readonly OrderMicroserviceDbContext _context;

        public ShoppingCartItemRepository(OrderMicroserviceDbContext context)
        {
            _context = context;
        }

        public async Task<ShoppingCartItem> GetItemByIdAsync(int itemId)
        {
            return await _context.ShoppingCartItems.FindAsync(itemId);
        }

        public async Task SaveItemAsync(ShoppingCartItem item)
        {
            if (item.Id == 0)
            {
                _context.ShoppingCartItems.Add(item);
            }
            else
            {
                _context.ShoppingCartItems.Update(item);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(int itemId)
        {
            var item = await _context.ShoppingCartItems.FindAsync(itemId);
            if (item != null)
            {
                _context.ShoppingCartItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}