using System.Diagnostics;
using eMovies.Models;
using eMovies.Services;
using eMovies.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eMovies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMoviesService _moviesService;

        public HomeController(ILogger<HomeController> logger, IMoviesService moviesService)
        {
            _logger = logger;
            _moviesService = moviesService;
        }

        public IActionResult Index()
        {
            HomeViewModel homeView = new HomeViewModel()
            {
                TopUpcommingMovies = _moviesService.GetTopUpcommingMoviesAsync().Result
            };

            return View(homeView);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
