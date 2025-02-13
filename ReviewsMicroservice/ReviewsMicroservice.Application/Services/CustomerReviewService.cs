using ReviewsMicroservice.Application.DTOs;
using ReviewsMicroservice.Application.Interfaces;
using ReviewsMicroservice.Domain.Entities;
using ReviewsMicroservice.Domain.Repositories;

namespace ReviewsMicroservice.Application.Services
{
    public class CustomerReviewService : ICustomerReviewService
    {
        private readonly ICustomerReviewRepository _reviewRepository;

        public CustomerReviewService(ICustomerReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<IEnumerable<CustomerReviewRequestModel>> GetAllAsync()
        {
            var reviews = await _reviewRepository.GetAllAsync();
            return reviews.Select(MapToDto);
        }

        public async Task<CustomerReviewRequestModel> GetByIdAsync(int id)
        {
            var review = await _reviewRepository.GetByIdAsync(id);
            return review == null ? null : MapToDto(review);
        }

        public async Task AddAsync(CustomerReviewRequestModel model)
        {
            var entity = MapToEntity(model);
            entity.Status = "Pending"; // Default to pending
            await _reviewRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(CustomerReviewRequestModel model)
        {
            var existing = await _reviewRepository.GetByIdAsync(model.Id);
            if (existing == null) return;

            existing.CustomerId = model.CustomerId;
            existing.CustomerName = model.CustomerName;
            existing.OrderId = model.OrderId;
            existing.OrderDate = model.OrderDate;
            existing.ProductId = model.ProductId;
            existing.ProductName = model.ProductName;
            existing.RatingValue = model.RatingValue;
            existing.Comment = model.Comment;
            existing.ReviewDate = model.ReviewDate;
            existing.Status = model.Status;

            await _reviewRepository.UpdateAsync(existing);
        }

        public async Task DeleteAsync(int id)
        {
            await _reviewRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CustomerReviewRequestModel>> GetByUserIdAsync(int userId)
        {
            var reviews = await _reviewRepository.GetByUserIdAsync(userId);
            return reviews.Select(MapToDto);
        }

        public async Task<IEnumerable<CustomerReviewRequestModel>> GetByProductIdAsync(int productId)
        {
            var reviews = await _reviewRepository.GetByProductIdAsync(productId);
            return reviews.Select(MapToDto);
        }

        public async Task ApproveReviewAsync(int id)
        {
            var review = await _reviewRepository.GetByIdAsync(id);
            if (review != null && review.Status == "Pending")
            {
                review.Status = "Approved";
                await _reviewRepository.UpdateAsync(review);
            }
        }

        public async Task RejectReviewAsync(int id)
        {
            var review = await _reviewRepository.GetByIdAsync(id);
            if (review != null && review.Status == "Pending")
            {
                review.Status = "Rejected";
                await _reviewRepository.UpdateAsync(review);
            }
        }
        
        public async Task<IEnumerable<CustomerReviewRequestModel>> GetByYearAsync(int year)
        {
            var reviews = await _reviewRepository.GetByYearAsync(year);
            return reviews.Select(MapToDto);
        }

        // Helper methods
        private static CustomerReviewRequestModel MapToDto(CustomerReview entity)
        {
            return new CustomerReviewRequestModel
            {
                Id = entity.Id,
                CustomerId = entity.CustomerId,
                CustomerName = entity.CustomerName,
                OrderId = entity.OrderId,
                OrderDate = entity.OrderDate,
                ProductId = entity.ProductId,
                ProductName = entity.ProductName,
                RatingValue = entity.RatingValue,
                Comment = entity.Comment,
                ReviewDate = entity.ReviewDate,
                Status = entity.Status
            };
        }

        private static CustomerReview MapToEntity(CustomerReviewRequestModel dto)
        {
            return new CustomerReview
            {
                Id = dto.Id,
                CustomerId = dto.CustomerId,
                CustomerName = dto.CustomerName,
                OrderId = dto.OrderId,
                OrderDate = dto.OrderDate,
                ProductId = dto.ProductId,
                ProductName = dto.ProductName,
                RatingValue = dto.RatingValue,
                Comment = dto.Comment,
                ReviewDate = dto.ReviewDate,
                Status = dto.Status
            };
        }
    }
}
