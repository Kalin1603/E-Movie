using eMovies.Base;
using eMovies.Data;
using eMovies.Models;

namespace eMovies.Services
{
    public class MoviesService : EntityBaseRepositoryL<Movie>, IMoviesService
    {
        public MoviesService(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
