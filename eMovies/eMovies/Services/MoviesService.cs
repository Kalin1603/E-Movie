using eMovies.Base;
using eMovies.Data;
using eMovies.Models;
using eMovies.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace eMovies.Services
{
    public class MoviesService : EntityBaseRepositoryL<Movie>, IMoviesService
    {
        public MoviesService(ApplicationDbContext context)
            : base(context)
        {
        }
        public async Task<ICollection<Movie>> GetAllMoviesAsync()
        {
            var movies = await _context.Movies.Include(m => m.Cinema).Include(m => m.Producer).OrderBy(m => m.Title).ToListAsync();
            return movies;
        }

        public async Task<Movie> GetMovieByIdAsync(int? id)
        {
            return await _context.Movies.Include(m => m.Cinema).Include(m => m.Producer).Include(m => m.Actors).ThenInclude(ma => ma.Actor).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddNewMovieAsync(MovieViewModel data)
        {
            var newMovie = new Movie
            {
                MovieImageURL = data.MovieImageURL,
                Title = data.Title,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                Price = data.Price,
                CinemaId = data.CinemaId,
                Category = data.Category,
                ProducerId = data.ProducerId,
                Description = data.Description
            };
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            if (data.ActorIds != null && data.ActorIds.Any())
            {
                var newActorMovies = data.ActorIds.Select(actorId => new ActorMovie
                {
                    ActorId = actorId,
                    MovieId = newMovie.Id
                })
                .ToList();
                await _context.ActorMovies.AddRangeAsync(newActorMovies);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateMovieAsync(MovieViewModel data)
        {
            var newMovie = _context.Movies.FirstOrDefault(nm => nm.Id == data.Id);

            if (newMovie != null)
            {
                newMovie.MovieImageURL = data.MovieImageURL;
                newMovie.Title = data.Title;
                newMovie.StartDate = data.StartDate;
                newMovie.EndDate = data.EndDate;
                newMovie.Price = data.Price;
                newMovie.CinemaId = data.CinemaId;
                newMovie.Category = data.Category;
                newMovie.ProducerId = data.ProducerId;
                newMovie.Description = data.Description;
                await _context.SaveChangesAsync();
            }

            if (data.ActorIds != null && data.ActorIds.Any())
            {
                var existingActorMovies = await _context.ActorMovies
                    .Where(am => am.MovieId == data.Id)
                    .ToListAsync();

                var newActorMovies = data.ActorIds
                    .Where(actorId => !existingActorMovies.Any(eam => eam.ActorId == actorId))
                    .Select(actorId => new ActorMovie
                    {
                        ActorId = actorId,
                        MovieId = data.Id
                    })
                    .ToList();

                if (newActorMovies.Any())
                {
                    await _context.ActorMovies.AddRangeAsync(newActorMovies);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task<TopUpcommingMoviesViewModel> GetTopUpcommingMoviesAsync()
        {
            var topMovies = new TopUpcommingMoviesViewModel();

            topMovies.UpcommingMovies = await _context.Movies
                .Where(m => m.StartDate > DateTime.Now)
                .OrderBy(m => m.StartDate)
                .Take(6)
                .Select(m => new MovieViewModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    MovieImageURL = m.MovieImageURL,
                    StartDate = m.StartDate,
                    EndDate = m.EndDate,
                    Price = m.Price,
                    Category = m.Category
                })
                .ToListAsync();
            return topMovies;
        }
    }
}
