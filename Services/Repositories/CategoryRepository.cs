using InternetStore.Context;
using InternetStore.Models;
using InternetStore.Services.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace InternetStore.Services.Repositories
{
    public sealed class CategoryRepository : ICategoryRepository
    {
        protected InternetStoreContext _context;
        protected DbSet<Category> dbSet;

        public CategoryRepository(InternetStoreContext context)
        {
            _context = context;
            this.dbSet = _context.Set<Category>();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
