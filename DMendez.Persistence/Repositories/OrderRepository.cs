using DMendez.Application.Interfaces.Repositories;
using DMendez.Domain.Entities.Orders;
using DMendez.Persistence.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DMendez.Persistence.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(DMendezDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Order>> GetByUserIdAsync(int userId)
        {
            return await _dbSet
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Include(o => o.OrderStatus)
                .Include(o => o.Payment)
                .Where(o => o.UserId == userId && !o.IsDeleted)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();
        }

        public async Task<Order> GetByIdWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Include(o => o.OrderStatus)
                .Include(o => o.Payment)
                .Include(o => o.User)
                .Include(o => o.DeliveryAddress)
                .FirstOrDefaultAsync(o => o.Id == id && !o.IsDeleted);
        }

        public async Task<Order> GetByOrderNumberAsync(string orderNumber)
        {
            return await _dbSet
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Include(o => o.OrderStatus)
                .FirstOrDefaultAsync(o => o.OrderNumber == orderNumber && !o.IsDeleted);
        }

        public async Task<IEnumerable<Order>> GetPendingOrdersAsync()
        {
            return await _dbSet
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Include(o => o.User)
                .Include(o => o.OrderStatus)
                .Where(o => o.OrderStatus.Name == "Pendiente" && !o.IsDeleted)
                .OrderBy(o => o.CreatedAt)
                .ToListAsync();
        }

        public override async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _dbSet
                .Include(o => o.User)
                .Include(o => o.OrderStatus)
                .Where(o => !o.IsDeleted)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();
        }
    }
}