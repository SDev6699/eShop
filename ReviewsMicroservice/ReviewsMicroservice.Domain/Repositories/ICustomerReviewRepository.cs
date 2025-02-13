using ReviewsMicroservice.Domain.Entities;

namespace ReviewsMicroservice.Domain.Repositories
{
    public interface ICustomerReviewRepository
    {
        Task<IEnumerable<CustomerReview>> GetAllAsync();
        Task<CustomerReview> GetByIdAsync(int id);
        Task AddAsync(CustomerReview review);
        Task UpdateAsync(CustomerReview review);
        Task DeleteAsync(int id);

        // Additional queries
        Task<IEnumerable<CustomerReview>> GetByUserIdAsync(int userId);
        Task<IEnumerable<CustomerReview>> GetByProductIdAsync(int productId);
        Task<IEnumerable<CustomerReview>> GetByYearAsync(int year);
    }
}