using eMovies.Models;
using System.Linq.Expressions;

namespace eMovies.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        Task<ICollection<T>> GetAllAsync();

        Task<ICollection<Movie>> GetAllMoviesAsync();

        Task<T> GetByIdAsync(int? id);
        Task<Movie> GetMovieByIdAsync(int? id);

        Task AddAsync(T entity);

        Task<T> FindAsync(int? id);

        Task UpdateAsync(T newEntity);

        Task DeleteAsync(T removedEntity);

        bool CheckExists(int id);
    }
}
