using ShippingMicroservice.Application.DTOs;
using ShippingMicroservice.Application.Interfaces;
using ShippingMicroservice.Domain.Entities;
using ShippingMicroservice.Domain.Repositories;

namespace ShippingMicroservice.Application.Services
{
    public class ShipperService : IShipperService
    {
        private readonly IShipperRepository _shipperRepository;

        public ShipperService(IShipperRepository shipperRepository)
        {
            _shipperRepository = shipperRepository;
        }

        public async Task<IEnumerable<ShipperRequestModel>> GetAllShippersAsync()
        {
            var shippers = await _shipperRepository.GetAllShippersAsync();
            return shippers.Select(s => new ShipperRequestModel
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Phone = s.Phone,
                ContactPerson = s.ContactPerson
            });
        }

        public async Task<ShipperRequestModel> GetShipperByIdAsync(int id)
        {
            var shipper = await _shipperRepository.GetShipperByIdAsync(id);
            if (shipper == null) return null;

            return new ShipperRequestModel
            {
                Id = shipper.Id,
                Name = shipper.Name,
                Email = shipper.Email,
                Phone = shipper.Phone,
                ContactPerson = shipper.ContactPerson
            };
        }

        public async Task AddShipperAsync(ShipperRequestModel model)
        {
            var entity = new Shipper
            {
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                ContactPerson = model.ContactPerson
            };
            await _shipperRepository.AddShipperAsync(entity);
        }

        public async Task UpdateShipperAsync(ShipperRequestModel model)
        {
            var entity = new Shipper
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                ContactPerson = model.ContactPerson
            };
            await _shipperRepository.UpdateShipperAsync(entity);
        }

        public async Task DeleteShipperAsync(int id)
        {
            await _shipperRepository.DeleteShipperAsync(id);
        }

        public async Task<IEnumerable<ShipperRequestModel>> GetShippersByRegionAsync(string regionName)
        {
            var shippers = await _shipperRepository.GetShippersByRegionAsync(regionName);
            return shippers.Select(s => new ShipperRequestModel
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Phone = s.Phone,
                ContactPerson = s.ContactPerson
            });
        }
    }
}
