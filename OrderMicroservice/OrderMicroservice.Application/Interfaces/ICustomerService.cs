using OrderMicroservice.Application.DTOs;

namespace OrderMicroservice.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<AddressDto> GetCustomerAddressByUserId(string userId);
        Task SaveCustomerAddress(AddressDto addressDto, string userId);
    }
}