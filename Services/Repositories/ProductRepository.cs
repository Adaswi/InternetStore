using InternetStore.Context;
using InternetStore.Models;
using InternetStore.Services.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace InternetStore.Services.Repositories
{
    public sealed class ProductRepository : IProductRepository
    {
        protected InternetStoreContext _context;
        protected DbSet<Product> dbSet;

        public ProductRepository(InternetStoreContext context)
        {
            _context = context;
            this.dbSet = _context.Set<Product>();
        }

        public async Task<Product> GetByIdAsync(decimal id)
        {
            try
            {
                return await dbSet.Include(x => x.User).Include(x => x.Category).Include(x => x.OptionPack).ThenInclude(x => x.Options).FirstOrDefaultAsync(x => x.ProductId == id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Product>> GetAllVisibleAsync()
        {
            try
            {
                return await dbSet.Include(x => x.User).Include(x => x.Category).Where(x => x.ProductVisibility == true).ToListAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
