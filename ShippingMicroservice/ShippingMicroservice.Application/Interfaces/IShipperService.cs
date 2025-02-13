using ShippingMicroservice.Application.DTOs;

namespace ShippingMicroservice.Application.Interfaces
{
    public interface IShipperService
    {
        Task<IEnumerable<ShipperRequestModel>> GetAllShippersAsync();
        Task<ShipperRequestModel> GetShipperByIdAsync(int id);
        Task AddShipperAsync(ShipperRequestModel model);
        Task UpdateShipperAsync(ShipperRequestModel model);
        Task DeleteShipperAsync(int id);
        Task<IEnumerable<ShipperRequestModel>> GetShippersByRegionAsync(string regionName);
    }
}