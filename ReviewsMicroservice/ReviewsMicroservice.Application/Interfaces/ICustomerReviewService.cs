using ReviewsMicroservice.Application.DTOs;

namespace ReviewsMicroservice.Application.Interfaces
{
    public interface ICustomerReviewService
    {
        Task<IEnumerable<CustomerReviewRequestModel>> GetAllAsync();
        Task<CustomerReviewRequestModel> GetByIdAsync(int id);
        Task AddAsync(CustomerReviewRequestModel model);
        Task UpdateAsync(CustomerReviewRequestModel model);
        Task DeleteAsync(int id);

        // Additional queries
        Task<IEnumerable<CustomerReviewRequestModel>> GetByUserIdAsync(int userId);
        Task<IEnumerable<CustomerReviewRequestModel>> GetByProductIdAsync(int productId);

        // Admin actions
        Task ApproveReviewAsync(int id);
        Task RejectReviewAsync(int id);
        
        Task<IEnumerable<CustomerReviewRequestModel>> GetByYearAsync(int year);
    }
}