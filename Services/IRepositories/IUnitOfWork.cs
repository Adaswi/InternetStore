namespace InternetStore.Services.IRepositories
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; } // we have only get because we don't want to set the repository. setting the repository will be done in the UnitOfWork class
        IProductRepository Products { get; }
        ICartRepository Carts { get; }
        IItemRepository Items { get; }
        ICategoryRepository Categories { get; }

        Task CompleteAsync();
    }
}
