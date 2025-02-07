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
using eMovies.Enums;
using Microsoft.AspNetCore.Authorization;

namespace eMovies.Controllers
{
    [Authorize]
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

        [AllowAnonymous]
        public async Task<IActionResult> AddItemToShoppingCard(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                TempData["StatusMessage"] = "You need to be logged in to add items to the shopping card.";
                return LocalRedirect($"/Identity/Account/Login?ReturnUrl=/Orders/AddItemToShoppingCard/{id}");
            }

            var selectedMovie = await _moviesService.GetMovieByIdAsync(id);
            if (selectedMovie != null)
            {
                await _shoppingCard.AddItemToCardAsync(selectedMovie);
            }
            return RedirectToAction("ShoppingCard");
        }

        public async Task<IActionResult> RemoveItemFromShoppingCard(int id)
        {
            var selectedMovie = await _moviesService.GetMovieByIdAsync(id);
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

            var order = new Order
            {
                UserId = userId,
                Email = userEmailAddress,
                Status = OrderStatus.Pending,
                OrderItems = items.Select(item => new OrderItem
                {
                    MovieId = item.Movie.Id,
                    Quantity = item.Quantity,
                    Price = item.Movie.Price
                }).ToList()
            };

            await _ordersService.StoreOrderAsync(items, userId);
            await _shoppingCard.ClearShoppingCardAsync();

            return View("OrderComplete");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeOrderStatus(int orderId, OrderStatus newStatus)
        {
            var order = await _ordersService.GetOrderByIdAsync(orderId);
            if (order != null)
            {
                if (order.Status == OrderStatus.Pending)
                {
                    order.Status = newStatus;

                    await _ordersService.UpdateOrderStatusAsync(order);

                    return RedirectToAction("Index");
                }
                else
                {
                    return BadRequest("Cannot change status of a completed order.");
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
}
