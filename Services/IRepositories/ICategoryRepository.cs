using InternetStore.Models;

namespace InternetStore.Services.IRepositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
    }
}
