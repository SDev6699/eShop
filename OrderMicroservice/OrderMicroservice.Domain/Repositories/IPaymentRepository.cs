using OrderMicroservice.Domain.Entities;

namespace OrderMicroservice.Domain.Repositories
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetPaymentsByCustomerIdAsync(int customerId);
        Task AddPaymentAsync(Payment payment);
        Task DeletePaymentAsync(int paymentId);
    }
}