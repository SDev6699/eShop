using System.Linq;
using OrderMicroservice.Application.DTOs;
using OrderMicroservice.Application.Interfaces;
using OrderMicroservice.Domain.Entities;
using OrderMicroservice.Domain.Repositories;

namespace OrderMicroservice.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        public async Task<AddressDto> GetCustomerAddressByUserId(string userId)
        {
            var customer = await _customerRepository.GetCustomerByUserIdAsync(userId);
            if (customer == null || customer.Addresses == null || !customer.Addresses.Any())
                return null;
            
            var address = customer.Addresses.FirstOrDefault(a => a.IsDefaultAddress)
                          ?? customer.Addresses.First();
            
            return new AddressDto
            {
                Id = address.Id,
                Street1 = address.Street1,
                Street2 = address.Street2,
                City = address.City,
                Zipcode = address.Zipcode,
                State = address.State,
                Country = address.Country,
                IsDefaultAddress = address.IsDefaultAddress
            };
        }
        
        public async Task SaveCustomerAddress(AddressDto addressDto, string userId)
        {
            // In a real scenario, retrieve the customer by userId and set CustomerId accordingly.
            var address = new Address
            {
                Id = addressDto.Id, // 0 if new
                Street1 = addressDto.Street1,
                Street2 = addressDto.Street2,
                City = addressDto.City,
                Zipcode = addressDto.Zipcode,
                State = addressDto.State,
                Country = addressDto.Country,
                IsDefaultAddress = addressDto.IsDefaultAddress
            };
            
            await _customerRepository.SaveCustomerAddressAsync(address);
        }
    }
}
