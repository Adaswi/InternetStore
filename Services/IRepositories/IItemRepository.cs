using InternetStore.Models;

namespace InternetStore.Services.IRepositories
{
    public interface IItemRepository
    {
        Task<bool> Insert(Item item);
        Task<IEnumerable<Item>> GetAllVisibleByCartAsync(decimal id);
        Task<Item> GetByIdAsync(decimal id);
    }
}
