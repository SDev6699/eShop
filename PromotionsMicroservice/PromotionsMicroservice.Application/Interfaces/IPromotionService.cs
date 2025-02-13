using PromotionsMicroservice.Application.DTOs;

namespace PromotionsMicroservice.Application.Interfaces
{
    public interface IPromotionService
    {
        Task<IEnumerable<PromotionRequestModel>> GetAllPromotionsAsync();
        Task<PromotionRequestModel> GetPromotionByIdAsync(int id);
        Task AddPromotionAsync(PromotionRequestModel model);
        Task UpdatePromotionAsync(PromotionRequestModel model);
        Task DeletePromotionAsync(int id);

        // Additional queries
        Task<IEnumerable<PromotionRequestModel>> GetPromotionsByProductNameAsync(string productName);
        Task<IEnumerable<PromotionRequestModel>> GetActivePromotionsAsync();
    }
}