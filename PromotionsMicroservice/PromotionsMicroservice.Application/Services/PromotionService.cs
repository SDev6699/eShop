using PromotionsMicroservice.Application.DTOs;
using PromotionsMicroservice.Application.Interfaces;
using PromotionsMicroservice.Domain.Entities;
using PromotionsMicroservice.Domain.Repositories;

namespace PromotionsMicroservice.Application.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly IPromotionRepository _promotionRepository;

        public PromotionService(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }

        public async Task<IEnumerable<PromotionRequestModel>> GetAllPromotionsAsync()
        {
            var promotions = await _promotionRepository.GetAllPromotionsAsync();
            return promotions.Select(MapToDto);
        }

        public async Task<PromotionRequestModel> GetPromotionByIdAsync(int id)
        {
            var promotion = await _promotionRepository.GetPromotionByIdAsync(id);
            return promotion == null ? null : MapToDto(promotion);
        }

        public async Task AddPromotionAsync(PromotionRequestModel model)
        {
            var entity = MapToEntity(model);
            await _promotionRepository.AddPromotionAsync(entity);
        }

        public async Task UpdatePromotionAsync(PromotionRequestModel model)
        {
            var existing = await _promotionRepository.GetPromotionByIdAsync(model.Id);
            if (existing == null) return;

            existing.Name = model.Name;
            existing.Description = model.Description;
            existing.Discount = model.Discount;
            existing.StartDate = model.StartDate;
            existing.EndDate = model.EndDate;

            await _promotionRepository.UpdatePromotionAsync(existing);
        }

        public async Task DeletePromotionAsync(int id)
        {
            await _promotionRepository.DeletePromotionAsync(id);
        }

        public async Task<IEnumerable<PromotionRequestModel>> GetPromotionsByProductNameAsync(string productName)
        {
            var promotions = await _promotionRepository.GetPromotionsByProductNameAsync(productName);
            return promotions.Select(MapToDto);
        }

        public async Task<IEnumerable<PromotionRequestModel>> GetActivePromotionsAsync()
        {
            var promotions = await _promotionRepository.GetActivePromotionsAsync();
            return promotions.Select(MapToDto);
        }

        // Helper methods
        private static PromotionRequestModel MapToDto(Promotion entity)
        {
            return new PromotionRequestModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Discount = entity.Discount,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate
            };
        }

        private static Promotion MapToEntity(PromotionRequestModel dto)
        {
            return new Promotion
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Discount = dto.Discount,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate
            };
        }
    }
}
