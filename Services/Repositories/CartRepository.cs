using InternetStore.Context;
using InternetStore.Models;
using InternetStore.Services.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace InternetStore.Services.Repositories
{
    public sealed class CartRepository : ICartRepository
    {
        protected InternetStoreContext _context;
        protected DbSet<Cart> dbSet;

        public CartRepository(InternetStoreContext context)
        {
            _context = context;
            this.dbSet = _context.Set<Cart>();
        }

        public async Task<bool> Insert(Cart cart)
        {
            try
            {
                await dbSet.AddAsync(cart);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<Cart> GetCartByUserIdAsync(decimal id)
        {
            try
            {
                return await dbSet.Where(x => x.UserId == id).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
