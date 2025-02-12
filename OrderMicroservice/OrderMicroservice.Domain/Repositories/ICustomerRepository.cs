using OrderMicroservice.Domain.Entities;

namespace OrderMicroservice.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerByUserIdAsync(string userId);
        Task SaveCustomerAddressAsync(Address address);
    }
}