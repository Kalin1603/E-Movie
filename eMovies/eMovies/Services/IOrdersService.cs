using eMovies.Models;

namespace eMovies.Services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCardItem> items, string userId);
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
    }
}
