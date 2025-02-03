using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eMovies.Data;
using eMovies.Models;
using eMovies.Services;
using eMovies.Card;
using System.Security.Claims;
using eMovies.ViewModels;

namespace eMovies.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IMoviesService _moviesService;
        private readonly ShoppingCard _shoppingCard;
        private readonly IOrdersService _ordersService;

        public OrdersController(IMoviesService moviesService, ShoppingCard shoppingCard, IOrdersService ordersService)
        {
            _moviesService = moviesService;
            _shoppingCard = shoppingCard;
            _ordersService = ordersService;
        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
            return View(orders);
        }

        public IActionResult ShoppingCard()
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

        public async Task<IActionResult> AddItemToShoppingCard(int movieId)
        {
            var selectedMovie = await _moviesService.GetMovieByIdAsync(movieId);
            if (selectedMovie != null)
            {
                await _shoppingCard.AddItemToCardAsync(selectedMovie, 1);
            }
            return RedirectToAction("ShoppingCard");
        }

        public async Task<IActionResult> RemoveItemFromShoppingCard(int movieId)
        {
            var selectedMovie = await _moviesService.GetMovieByIdAsync(movieId);
            if (selectedMovie != null)
            {
                await _shoppingCard.RemoveItemFromCardAsync(selectedMovie);
            }
            return RedirectToAction("ShoppingCard");
        }
        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCard.GetShoppingCardItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            await _ordersService.StoreOrderAsync(items, userId);
            await _shoppingCard.ClearShoppingCardAsync();

            return View("OrderCompleted");
        }
    }
}
