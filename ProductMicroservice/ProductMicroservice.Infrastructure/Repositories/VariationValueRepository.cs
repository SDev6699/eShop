using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Domain.Entities;
using ProductMicroservice.Domain.Repositories;
using ProductMicroservice.Infrastructure.Data;

namespace ProductMicroservice.Infrastructure.Repositories
{
    public class VariationValueRepository : IVariationValueRepository
    {
        private readonly ProductMicroserviceDbContext _context;

        public VariationValueRepository(ProductMicroserviceDbContext context)
        {
            _context = context;
        }

        public async Task SaveVariationValueAsync(VariationValue value)
        {
            if (value.Id == 0)
                _context.VariationValues.Add(value);
            else
                _context.VariationValues.Update(value);

            await _context.SaveChangesAsync();
        }

        public async Task<VariationValue> GetVariationValueAsync(int id)
        {
            return await _context.VariationValues.FindAsync(id);
        }
    }
}