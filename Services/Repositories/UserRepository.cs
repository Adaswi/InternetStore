using InternetStore.Context;
using InternetStore.Models;
using InternetStore.Services.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace InternetStore.Services.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        protected InternetStoreContext _context;
        protected DbSet<User> dbSet;

        public UserRepository(InternetStoreContext context)
        {
            _context = context;
            this.dbSet = _context.Set<User>();
        }

        public async Task<User> GetByIdAsync(decimal id)
        {
            try
            {
                return await dbSet.FindAsync(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> Insert(User user)
        {
            try
            {
                await dbSet.AddAsync(user);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
