using DMendez.Application.Interfaces.Repositories;
using DMendez.Domain.Entities.Menu;
using DMendez.Persistence.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DMendez.Persistence.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DMendezDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId)
        {
            return await _dbSet
                .Include(p => p.Category)
                .Where(p => p.CategoryId == categoryId && !p.IsDeleted && p.IsAvailable)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAvailableProductsAsync()
        {
            return await _dbSet
                .Include(p => p.Category)
                .Where(p => p.IsAvailable && !p.IsDeleted)
                .OrderBy(p => p.Category.Name)
                .ThenBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<Product> GetByIdWithCategoryAsync(int id)
        {
            return await _dbSet
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
        }

        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbSet
                .Include(p => p.Category)
                .Where(p => !p.IsDeleted)
                .ToListAsync();
        }
    }
}