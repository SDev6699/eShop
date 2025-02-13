using ShippingMicroservice.Domain.Entities;

namespace ShippingMicroservice.Domain.Repositories
{
    public interface IShipperRepository
    {
        Task<IEnumerable<Shipper>> GetAllShippersAsync();
        Task<Shipper> GetShipperByIdAsync(int id);
        Task AddShipperAsync(Shipper shipper);
        Task UpdateShipperAsync(Shipper shipper);
        Task DeleteShipperAsync(int id);
        Task<IEnumerable<Shipper>> GetShippersByRegionAsync(string regionName);
    }
}