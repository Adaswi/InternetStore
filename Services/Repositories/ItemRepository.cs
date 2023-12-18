using InternetStore.Context;
using InternetStore.Models;
using InternetStore.Services.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace InternetStore.Services.Repositories
{
    public sealed class ItemRepository : IItemRepository
    {
        protected InternetStoreContext _context;
        protected DbSet<Item> dbSet;

        public ItemRepository(InternetStoreContext context)
        {
            _context = context;
            this.dbSet = _context.Set<Item>();
        }

        public async Task<bool> Insert(Item item)
        {
            try
            {
                await dbSet.AddAsync(item);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public async Task<IEnumerable<Item>> GetAllVisibleAsync()
        {
            try
            {
                return await dbSet.Where(x => x.ItemVisible == true).ToListAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
