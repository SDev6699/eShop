using System.Linq;
using OrderMicroservice.Application.DTOs;
using OrderMicroservice.Application.Interfaces;
using OrderMicroservice.Domain.Entities;
using OrderMicroservice.Domain.Repositories;

namespace OrderMicroservice.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        
        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        
        public async Task<IEnumerable<PaymentDto>> GetPaymentsByCustomerId(int customerId)
        {
            var payments = await _paymentRepository.GetPaymentsByCustomerIdAsync(customerId);
            return payments.Select(p => new PaymentDto
            {
                Id = p.Id,
                CustomerId = p.CustomerId,
                PaymentTypeId = p.PaymentTypeId,
                Provider = p.Provider,
                AccountNumber = p.AccountNumber,
                Expiry = p.Expiry,
                IsDefault = p.IsDefault
            });
        }
        
        public async Task SavePayment(PaymentDto dto)
        {
            var payment = new Payment
            {
                Id = dto.Id,
                CustomerId = dto.CustomerId,
                PaymentTypeId = dto.PaymentTypeId,
                Provider = dto.Provider,
                AccountNumber = dto.AccountNumber,
                Expiry = dto.Expiry,
                IsDefault = dto.IsDefault
            };
            
            await _paymentRepository.AddPaymentAsync(payment);
        }
        
        public async Task DeletePayment(int paymentId)
        {
            await _paymentRepository.DeletePaymentAsync(paymentId);
        }
        
        public async Task UpdatePaymentAsync(PaymentDto dto)
        {
            // Option 1: Retrieve existing payment and update its fields.
            // Option 2: Simply use the repository's update logic if AddPaymentAsync handles updates when dto.Id != 0.
            // Here, we'll assume we want to update explicitly.
            var payment = new Payment
            {
                Id = dto.Id,
                CustomerId = dto.CustomerId,
                PaymentTypeId = dto.PaymentTypeId,
                Provider = dto.Provider,
                AccountNumber = dto.AccountNumber,
                Expiry = dto.Expiry,
                IsDefault = dto.IsDefault
            };
            await _paymentRepository.AddPaymentAsync(payment);
        }
    }
}