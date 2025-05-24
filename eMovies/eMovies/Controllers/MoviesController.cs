﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eMovies.Data;
using eMovies.Models;
using eMovies.Services;
using eMovies.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace eMovies.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MoviesController : Controller
    {
        private readonly IMoviesService _moviesService;
        private readonly ICinemasService _cinemasService;
        private readonly IProducersService _producersService;
        private readonly IActorsService _actorsService;

        public MoviesController(IMoviesService moviesService, ICinemasService cinemasService, IProducersService producersService, IActorsService actorsService)
        {
            _moviesService = moviesService;
            _cinemasService = cinemasService;
            _producersService = producersService;
            _actorsService = actorsService;
        }

        [AllowAnonymous]
        // GET: Movies
        public async Task<IActionResult> Index(int page = 1, int pageSize = 3, string category = null, string filter = null)
        {
            var allMovies = await _moviesService.GetAllMoviesAsync();

            if (!string.IsNullOrEmpty(category))
            {
                allMovies = allMovies.Where(m => m.Category.ToString().Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
                if (!allMovies.Any())
                {
                    ViewData["StatusMessage"] = "No available movies with this category!";
                }
            }

            if (!string.IsNullOrEmpty(filter))
            {
                switch (filter)
                {
                    case "LowToHigh":
                        allMovies = allMovies.OrderBy(m => m.Price).ToList();
                        break;
                    case "HighToLow":
                        allMovies = allMovies.OrderByDescending(m => m.Price).ToList();
                        break;
                    case "asc":
                        allMovies = allMovies.OrderBy(m => m.Title).ToList();
                        break;
                    case "desc":
                        allMovies = allMovies.OrderByDescending(m => m.Title).ToList();
                        break;
                }
            }

            var paginatedMovies = allMovies
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var totalMovies = allMovies.Count();
            var totalPages = (int)Math.Ceiling(totalMovies / (double)pageSize);

            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = totalPages;
            ViewData["SelectedCategory"] = category;
            ViewData["SelectedPriceFilter"] = filter; 
            ViewData["SelectedSortOrder"] = filter;

            return View(paginatedMovies);
        }

        [AllowAnonymous]
        //Search Movies
        public async Task<IActionResult> Search(string searchString)
        {
            var movies = await _moviesService.GetAllMoviesAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredMovie = movies.Where(s => s.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
                if (filteredMovie.Any())
                {
                    return View("Index", filteredMovie);
                }
                else
                {
                    ViewBag.Message = "No movies found for your search.";
                    return View("NotFoundMovie");
                }
            }
            return View("NotFoundMovie");
        }

        [AllowAnonymous]
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
            var actors = await _actorsService.GetAllActorsAsync();

            ViewData["CinemaId"] = new SelectList(cinemas, "Id", "Name");

            ViewData["ProducerId"] = new SelectList(
            producers.Select(p => new
            {
                p.Id,
                FullName = p.FirstName + " " + p.LastName
            }),
            "Id",
            "FullName");

            ViewData["Actors"] = new SelectList(
            actors.Select(a => new
            {
                a.Id,
                FullName = a.FirstName + " " + a.LastName
            }),
            "Id",
            "FullName");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Price,MovieImageURL,StartDate,EndDate,Category,CinemaId,ProducerId,ActorIds")] MovieViewModel movie)
        {
            if (ModelState.IsValid)
            {
                await _moviesService.AddNewMovieAsync(movie);
                return RedirectToAction(nameof(Index));
            }
            var cinemas = await _cinemasService.GetAllCinemasAsync();
            var producers = await _producersService.GetAllProducersAsync();
            var actors = await _actorsService.GetAllActorsAsync();

            ViewData["CinemaId"] = new SelectList(cinemas, "Id", "Name");

            ViewData["ProducerId"] = new SelectList(
            producers.Select(p => new
            {
                p.Id,
                FullName = p.FirstName + " " + p.LastName
            }),
            "Id",
            "FullName");

            ViewData["Actors"] = new SelectList(
            actors.Select(a => new
            {
                a.Id,
                FullName = a.FirstName + " " + a.LastName
            }),
            "Id",
            "FullName");
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

            var response = new MovieViewModel()
            {
                Id = movie.Id,
                MovieImageURL = movie.MovieImageURL,
                Title = movie.Title,
                StartDate = movie.StartDate,
                EndDate = movie.EndDate,
                Price = movie.Price,
                CinemaId = movie.CinemaId,
                Category = movie.Category,
                ProducerId = movie.ProducerId,
                Description = movie.Description,
                ActorIds = movie.Actors.Select(am => am.ActorId).ToList()
            };

            var cinemas = await _cinemasService.GetAllCinemasAsync();
            var producers = await _producersService.GetAllProducersAsync();
            var actors = await _actorsService.GetAllActorsAsync();

            ViewData["CinemaId"] = new SelectList(cinemas, "Id", "Name", movie.CinemaId);

            ViewData["ProducerId"] = new SelectList(
            producers.Select(p => new
            {
                p.Id,
                FullName = p.FirstName + " " + p.LastName
            }),
            "Id",
            "FullName",
             movie.ProducerId);

            ViewData["Actors"] = new SelectList(
            actors.Select(a => new
            {
                a.Id,
                FullName = a.FirstName + " " + a.LastName
            }),
            "Id",
            "FullName",
             movie.Actors);

            return View(response);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Price,MovieImageURL,StartDate,EndDate,Category,CinemaId,ProducerId,ActorIds")] MovieViewModel movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _moviesService.UpdateMovieAsync(movie);
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
            var actors = await _actorsService.GetAllActorsAsync();

            ViewData["CinemaId"] = new SelectList(cinemas, "Id", "Name", movie.CinemaId);

            ViewData["ProducerId"] = new SelectList(
            producers.Select(p => new
            {
                p.Id,
                FullName = p.FirstName + " " + p.LastName
            }),
            "Id",
            "FullName",
             movie.ProducerId);

            ViewData["Actors"] = new SelectList(
            actors.Select(a => new
            {
                a.Id,
                FullName = a.FirstName + " " + a.LastName
            }),
            "Id",
            "FullName",
             movie.ActorIds);
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
