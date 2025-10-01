using DMendez.Application.Interfaces.Repositories;
using DMendez.Domain.Entities.Menu;
using DMendez.Persistence.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DMendez.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DMendezDbContext context) : base(context)
        {
        }

        public async Task<Category> GetByIdWithProductsAsync(int id)
        {
            return await _dbSet
                .Include(c => c.Products.Where(p => !p.IsDeleted))
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
        }

        public async Task<IEnumerable<Category>> GetCategoriesWithProductsAsync()
        {
            return await _dbSet
                .Include(c => c.Products.Where(p => !p.IsDeleted && p.IsAvailable))
                .Where(c => !c.IsDeleted)
                .ToListAsync();
        }

        public override async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _dbSet
                .Where(c => !c.IsDeleted)
                .OrderBy(c => c.Name)
                .ToListAsync();
        }
    }
}