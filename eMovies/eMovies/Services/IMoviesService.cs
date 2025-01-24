using eMovies.Base;
using eMovies.Models;
using eMovies.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace eMovies.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<ICollection<Movie>> GetAllMoviesAsync();

        Task<Movie> GetMovieByIdAsync(int? id);

        Task AddNewMovieAsync(MovieViewModel data);

        Task UpdateMovieAsync(MovieViewModel data);

        Task <TopUpcommingMoviesViewModel> GetTopUpcommingMoviesAsync();
    }
}
