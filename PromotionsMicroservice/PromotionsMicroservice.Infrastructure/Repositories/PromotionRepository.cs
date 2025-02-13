using Microsoft.EntityFrameworkCore;
using PromotionsMicroservice.Domain.Entities;
using PromotionsMicroservice.Domain.Repositories;
using PromotionsMicroservice.Infrastructure.Data;

namespace PromotionsMicroservice.Infrastructure.Repositories
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly PromotionsMicroserviceDbContext _context;

        public PromotionRepository(PromotionsMicroserviceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Promotion>> GetAllPromotionsAsync()
        {
            return await _context.Promotions
                .Include(p => p.PromotionDetails)
                .ToListAsync();
        }

        public async Task<Promotion> GetPromotionByIdAsync(int id)
        {
            return await _context.Promotions
                .Include(p => p.PromotionDetails)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddPromotionAsync(Promotion promotion)
        {
            _context.Promotions.Add(promotion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePromotionAsync(Promotion promotion)
        {
            _context.Promotions.Update(promotion);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePromotionAsync(int id)
        {
            var promo = await _context.Promotions.FindAsync(id);
            if (promo != null)
            {
                _context.Promotions.Remove(promo);
                await _context.SaveChangesAsync();
            }
        }

        // For the "promotionByProductName" endpoint
        public async Task<IEnumerable<Promotion>> GetPromotionsByProductNameAsync(string productName)
        {
            // Example: find all promotions that have PromotionDetails with matching productName
            return await _context.Promotions
                .Include(p => p.PromotionDetails)
                .Where(p => p.PromotionDetails.Any(d => d.ProductCategoryName.Contains(productName)))
                .ToListAsync();
        }

        // For "activePromotions" endpoint
        public async Task<IEnumerable<Promotion>> GetActivePromotionsAsync()
        {
            var now = DateTime.UtcNow;
            return await _context.Promotions
                .Include(p => p.PromotionDetails)
                .Where(p => p.StartDate <= now && p.EndDate >= now)
                .ToListAsync();
        }
    }
}
