using InternetStore.Models;

namespace InternetStore.Services.IRepositories
{
    public interface ICartRepository
    {
        Task<bool> Insert(Cart cart);
        Task<Cart> GetCartByUserIdAsync(decimal id);
    }
}
