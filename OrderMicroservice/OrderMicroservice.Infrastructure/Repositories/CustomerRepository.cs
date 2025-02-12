using Microsoft.EntityFrameworkCore;
using OrderMicroservice.Domain.Entities;
using OrderMicroservice.Domain.Repositories;
using OrderMicroservice.Infrastructure.Data;

namespace OrderMicroservice.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly OrderMicroserviceDbContext _context;

        public CustomerRepository(OrderMicroserviceDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetCustomerByUserIdAsync(string userId)
        {
            return await _context.Customers
                .Include(c => c.Addresses)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task SaveCustomerAddressAsync(Address address)
        {
            if (address.Id == 0)
            {
                _context.Addresses.Add(address);
            }
            else
            {
                _context.Addresses.Update(address);
            }
            await _context.SaveChangesAsync();
        }
    }
}