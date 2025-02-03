using eMovies.Data;
using eMovies.Models;
using Microsoft.EntityFrameworkCore;

namespace eMovies.Card
{
    public class ShoppingCard
    {
        private readonly ApplicationDbContext _context;
        private readonly ISession _session;

        public string ShoppingCardId { get; set; }
        public List<ShoppingCardItem> ShoppingCardItems { get; set; }

        public ShoppingCard(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _session = httpContextAccessor.HttpContext.Session;

            ShoppingCardId = _session.GetString("ShoppingCardId") ?? Guid.NewGuid().ToString();
            _session.SetString("ShoppingCardId", ShoppingCardId);
        }

        public async Task AddItemToCardAsync(Movie movie, int quantity)
        {
            var shoppingCardItem = await _context.ShoppingCardItems
                .Where(sci => sci.MovieId == movie.Id && sci.ShoppingCardId == ShoppingCardId)
                .FirstOrDefaultAsync();
            if (shoppingCardItem == null)
            {
                shoppingCardItem = new ShoppingCardItem
                {
                    MovieId = movie.Id,
                    ShoppingCardId = ShoppingCardId,
                    Quantity = quantity,
                };
                await _context.ShoppingCardItems.AddAsync(shoppingCardItem);
            }
            else
            {
                shoppingCardItem.Quantity += quantity;
            }
            await _context.SaveChangesAsync();
        }

        public async Task RemoveItemFromCardAsync(Movie movie)
        {
            var shoppingCardItem = await _context.ShoppingCardItems
                .Where(sci => sci.MovieId == movie.Id && sci.ShoppingCardId == ShoppingCardId)
                .FirstOrDefaultAsync();
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
                await _context.SaveChangesAsync();
            }
        }

        public List<ShoppingCardItem> GetShoppingCardItems()
        {
            if (ShoppingCardItems != null)
            {
                return ShoppingCardItems;
            }

            ShoppingCardItems = _context.ShoppingCardItems
                .Where(n => n.ShoppingCardId == ShoppingCardId)
                .Include(n => n.Movie)
                .ToList();

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
        }
    }
}
