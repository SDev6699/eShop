using PromotionsMicroservice.Domain.Entities;

namespace PromotionsMicroservice.Domain.Repositories
{
    public interface IPromotionRepository
    {
        Task<IEnumerable<Promotion>> GetAllPromotionsAsync();
        Task<Promotion> GetPromotionByIdAsync(int id);
        Task AddPromotionAsync(Promotion promotion);
        Task UpdatePromotionAsync(Promotion promotion);
        Task DeletePromotionAsync(int id);

        // Additional queries
        Task<IEnumerable<Promotion>> GetPromotionsByProductNameAsync(string productName);
        Task<IEnumerable<Promotion>> GetActivePromotionsAsync();
    }
}