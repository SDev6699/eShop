using OrderMicroservice.Application.DTOs;

namespace OrderMicroservice.Application.Interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentDto>> GetPaymentsByCustomerId(int customerId);
        Task SavePayment(PaymentDto dto);
        Task DeletePayment(int paymentId);
        
        Task UpdatePaymentAsync(PaymentDto dto);

    }
}