using InternetStore.Context;
using InternetStore.Controllers;
using InternetStore.Services.IRepositories;

namespace InternetStore.Services.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable // IDisposable is used to free unmanaged resources
    {
        private readonly InternetStoreContext _context;

        public IUserRepository Users { get; private set; }
        public IProductRepository Products { get; private set; }
        public ICartRepository Carts { get; private set; }
        public IItemRepository Items { get; private set; }

        // constructor will take the context and logger factory as parameters
        public UnitOfWork(InternetStoreContext context)
        {
            _context = context;

            Users = new UserRepository(_context);
            Products = new ProductRepository(_context);
            Carts = new CartRepository(_context);
            Items = new ItemRepository(_context);

        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
