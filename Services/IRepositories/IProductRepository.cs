using InternetStore.Models;

namespace InternetStore.Services.IRepositories
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(decimal id);
        Task<IEnumerable<Product>> GetAllVisibleAsync();
    }
}
