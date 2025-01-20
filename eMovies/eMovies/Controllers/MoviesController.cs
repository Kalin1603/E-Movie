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

namespace eMovies.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _moviesService;
        private readonly ICinemasService _cinemasService;
        private readonly IProducersService _producersService;

        public MoviesController(IMoviesService moviesService, ICinemasService cinemasService, IProducersService producersService)
        {
            _moviesService = moviesService;
            _cinemasService = cinemasService;
            _producersService = producersService;
        }




        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var allMovies = _moviesService.GetAllMoviesAsync();
            return View(await allMovies);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _moviesService.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public async Task<IActionResult> Create()
        {
            var cinemas = await _cinemasService.GetAllCinemasAsync();
            var producers = await _producersService.GetAllProducersAsync();

            ViewData["CinemaId"] = new SelectList(cinemas, "Id", "Description");
            ViewData["ProducerId"] = new SelectList(producers, "Id", "FirstName");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Price,MovieImageURL,StartDate,EndDate,Category,CinemaId,ProducerId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                await _moviesService.AddAsync(movie);
                return RedirectToAction(nameof(Index));
            }
            var cinemas = await _cinemasService.GetAllCinemasAsync();
            var producers = await _producersService.GetAllProducersAsync();

            ViewData["CinemaId"] = new SelectList(cinemas, "Id", "Description", movie.CinemaId);
            ViewData["ProducerId"] = new SelectList(producers, "Id", "FirstName", movie.ProducerId);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _moviesService.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            var cinemas = await _cinemasService.GetAllCinemasAsync();
            var producers = await _producersService.GetAllProducersAsync();

            ViewData["CinemaId"] = new SelectList(cinemas, "Id", "Description", movie.CinemaId);
            ViewData["ProducerId"] = new SelectList(producers, "Id", "FirstName", movie.ProducerId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Price,MovieImageURL,StartDate,EndDate,Category,CinemaId,ProducerId")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _moviesService.UpdateAsync(movie);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var cinemas = await _cinemasService.GetAllCinemasAsync();
            var producers = await _producersService.GetAllProducersAsync();

            ViewData["CinemaId"] = new SelectList(cinemas, "Id", "Description", movie.CinemaId);
            ViewData["ProducerId"] = new SelectList(producers, "Id", "FirstName", movie.ProducerId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _moviesService.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _moviesService.FindAsync(id);
            if (movie != null)
            {
                await _moviesService.DeleteAsync(movie);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _moviesService.CheckExists(id);
        }
    }
}
