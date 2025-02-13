using Microsoft.EntityFrameworkCore;
using ShippingMicroservice.Domain.Entities;
using ShippingMicroservice.Domain.Repositories;
using ShippingMicroservice.Infrastructure.Data;

namespace ShippingMicroservice.Infrastructure.Repositories
{
    public class ShipperRepository : IShipperRepository
    {
        private readonly ShippingMicroserviceDbContext _context;

        public ShipperRepository(ShippingMicroserviceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Shipper>> GetAllShippersAsync()
        {
            return await _context.Shippers.ToListAsync();
        }

        public async Task<Shipper> GetShipperByIdAsync(int id)
        {
            return await _context.Shippers.FindAsync(id);
        }

        public async Task AddShipperAsync(Shipper shipper)
        {
            _context.Shippers.Add(shipper);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateShipperAsync(Shipper shipper)
        {
            _context.Shippers.Update(shipper);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteShipperAsync(int id)
        {
            var shipper = await _context.Shippers.FindAsync(id);
            if (shipper != null)
            {
                _context.Shippers.Remove(shipper);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Shipper>> GetShippersByRegionAsync(string regionName)
        {
            // Example: find region by name
            var region = await _context.Regions
                .FirstOrDefaultAsync(r => r.Name == regionName);

            if (region == null)
                return Enumerable.Empty<Shipper>();

            // Find active ShipperRegion records for that region
            var shipperIds = await _context.ShipperRegions
                .Where(sr => sr.RegionId == region.Id && sr.Active)
                .Select(sr => sr.ShipperId)
                .ToListAsync();

            return await _context.Shippers
                .Where(s => shipperIds.Contains(s.Id))
                .ToListAsync();
        }
    }
}
