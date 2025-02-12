using Microsoft.EntityFrameworkCore;
using OrderMicroservice.Domain.Entities;
using OrderMicroservice.Domain.Repositories;
using OrderMicroservice.Infrastructure.Data;

namespace OrderMicroservice.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly OrderMicroserviceDbContext _context;

        public PaymentRepository(OrderMicroserviceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByCustomerIdAsync(int customerId)
        {
            return await _context.Payments
                .Include(p => p.PaymentType)
                .Where(p => p.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task AddPaymentAsync(Payment payment)
        {
            if (payment.Id == 0)
            {
                _context.Payments.Add(payment);
            }
            else
            {
                _context.Payments.Update(payment);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeletePaymentAsync(int paymentId)
        {
            var payment = await _context.Payments.FindAsync(paymentId);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();
            }
        }
    }
}