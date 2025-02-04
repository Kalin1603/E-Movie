using eMovies.Data;
using eMovies.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace eMovies.Card
{
    public class ShoppingCard
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public string ShoppingCardId { get; set; }
        public List<ShoppingCardItem> ShoppingCardItems { get; set; }

        public ShoppingCard(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public static ShoppingCard GetCard(IServiceProvider services)
        {
            var context = services.GetRequiredService<ApplicationDbContext>();
            var httpContextAccessor = services.GetRequiredService<IHttpContextAccessor>();
            var session = httpContextAccessor.HttpContext.Session;
            var cardId = session.GetString("CardId") ?? Guid.NewGuid().ToString();
            session.SetString("CardId", cardId);
            return new ShoppingCard(context, httpContextAccessor) { ShoppingCardId = cardId };
        }

        public async Task AddItemToCardAsync(Movie movie)
        {
            var shoppingCardItem = await _context.ShoppingCardItems.FirstOrDefaultAsync(n => n.Movie.Id == movie.Id && n.ShoppingCardId == ShoppingCardId);

            if (shoppingCardItem == null)
            {
                shoppingCardItem = new ShoppingCardItem
                {
                    MovieId = movie.Id,
                    ShoppingCardId = ShoppingCardId,
                    Quantity = 1
                };
                await _context.ShoppingCardItems.AddAsync(shoppingCardItem);
            }
            else
            {
                shoppingCardItem.Quantity++;
            }
            await _context.SaveChangesAsync();
            SaveCartToSession();
        }

        public async Task RemoveItemFromCardAsync(Movie movie)
        {
            var shoppingCardItem = await _context.ShoppingCardItems.Where(sci => sci.MovieId == movie.Id && sci.ShoppingCardId == ShoppingCardId).FirstOrDefaultAsync();

            if (shoppingCardItem != null)
            {
                if (shoppingCardItem.Quantity > 1)
                {
                    shoppingCardItem.Quantity--;
                }
                else
                {
                    _context.ShoppingCardItems.Remove(shoppingCardItem);
                }
            }
            await _context.SaveChangesAsync();
            SaveCartToSession();
        }

        public List<ShoppingCardItem> GetShoppingCardItems()
        {
            if (ShoppingCardItems != null)
            {
                return ShoppingCardItems;
            }

            LoadCartFromSession();
            if (ShoppingCardItems == null)
            {
                ShoppingCardItems = _context.ShoppingCardItems
                    .Where(n => n.ShoppingCardId == ShoppingCardId)
                    .Include(n => n.Movie)
                    .ToList();
            }

            return ShoppingCardItems;
        }

        public double GetShoppingCardTotal()
        {
            var shoppingCardItems = GetShoppingCardItems();
            return shoppingCardItems.Sum(sci => sci.Movie.Price * sci.Quantity);
        }

        public async Task ClearShoppingCardAsync()
        {
            var shoppingCardItems = await _context.ShoppingCardItems
                .Where(sci => sci.ShoppingCardId == ShoppingCardId)
                .ToListAsync();

            _context.ShoppingCardItems.RemoveRange(shoppingCardItems);
            await _context.SaveChangesAsync();
            _httpContextAccessor.HttpContext.Session.Remove("ShoppingCardItems");
        }

        private void SaveCartToSession()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var cartJson = JsonConvert.SerializeObject(ShoppingCardItems);
            session.SetString("ShoppingCardItems", cartJson);
        }

        private void LoadCartFromSession()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var cartJson = session.GetString("ShoppingCardItems");
            if (!string.IsNullOrEmpty(cartJson))
            {
                ShoppingCardItems = JsonConvert.DeserializeObject<List<ShoppingCardItem>>(cartJson);
            }
        }
    }
}
