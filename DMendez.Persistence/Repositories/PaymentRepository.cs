using DMendez.Application.Interfaces.Repositories;
using DMendez.Domain.Entities.Payments;
using DMendez.Persistence.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DMendez.Persistence.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(DMendezDbContext context) : base(context)
        {
        }

        public async Task<Payment> GetByOrderIdAsync(int orderId)
        {
            return await _dbSet
                .Include(p => p.PaymentMethod)
                .Include(p => p.PaymentStatus)
                .Include(p => p.Order)
                .FirstOrDefaultAsync(p => p.OrderId == orderId && !p.IsDeleted);
        }

        public async Task<Payment> GetByTransactionIdAsync(string transactionId)
        {
            return await _dbSet
                .Include(p => p.PaymentMethod)
                .Include(p => p.PaymentStatus)
                .FirstOrDefaultAsync(p => p.TransactionId == transactionId && !p.IsDeleted);
        }

        public async Task<IEnumerable<Payment>> GetSuccessfulPaymentsAsync()
        {
            return await _dbSet
                .Include(p => p.Order)
                .Include(p => p.PaymentMethod)
                .Include(p => p.PaymentStatus)
                .Where(p => p.PaymentStatus.Name == "Aprobado" && !p.IsDeleted)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        public override async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _dbSet
                .Include(p => p.Order)
                .Include(p => p.PaymentMethod)
                .Include(p => p.PaymentStatus)
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }
    }
}