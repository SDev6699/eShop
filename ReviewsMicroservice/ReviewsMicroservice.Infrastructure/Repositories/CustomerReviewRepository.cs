using Microsoft.EntityFrameworkCore;
using ReviewsMicroservice.Domain.Entities;
using ReviewsMicroservice.Domain.Repositories;
using ReviewsMicroservice.Infrastructure.Data;

namespace ReviewsMicroservice.Infrastructure.Repositories
{
    public class CustomerReviewRepository : ICustomerReviewRepository
    {
        private readonly ReviewsMicroserviceDbContext _context;

        public CustomerReviewRepository(ReviewsMicroserviceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerReview>> GetAllAsync()
        {
            return await _context.CustomerReviews.ToListAsync();
        }

        public async Task<CustomerReview> GetByIdAsync(int id)
        {
            return await _context.CustomerReviews.FindAsync(id);
        }

        public async Task AddAsync(CustomerReview review)
        {
            _context.CustomerReviews.Add(review);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CustomerReview review)
        {
            _context.CustomerReviews.Update(review);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.CustomerReviews.FindAsync(id);
            if (entity != null)
            {
                _context.CustomerReviews.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CustomerReview>> GetByUserIdAsync(int userId)
        {
            return await _context.CustomerReviews
                .Where(r => r.CustomerId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<CustomerReview>> GetByProductIdAsync(int productId)
        {
            return await _context.CustomerReviews
                .Where(r => r.ProductId == productId)
                .ToListAsync();
        }
        public async Task<IEnumerable<CustomerReview>> GetByYearAsync(int year)
        {
            return await _context.CustomerReviews
                .Where(r => r.ReviewDate.Year == year)
                .ToListAsync();
        }

    }
}