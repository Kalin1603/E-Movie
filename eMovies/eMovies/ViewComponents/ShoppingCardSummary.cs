using eMovies.Card;
using eMovies.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eMovies.ViewComponents
{
    public class ShoppingCardSummary : ViewComponent
    {
        private readonly ShoppingCard _shoppingCard;
        public ShoppingCardSummary(ShoppingCard shoppingCard)
        {
            _shoppingCard = shoppingCard;
        }
        public IViewComponentResult Invoke()
        {
            var items = _shoppingCard.GetShoppingCardItems();
            _shoppingCard.ShoppingCardItems = items;
            var shoppingCartViewModel = new ShoppingCardViewModel
            {
                ShoppingCard = _shoppingCard,
                ShoppingCardTotal = _shoppingCard.GetShoppingCardTotal()
            };
            return View(shoppingCartViewModel);
        }
    }
}
