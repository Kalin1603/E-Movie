using eMovies.Models;

namespace eMovies.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        Task<ICollection<T>> GetAllAsync();

        Task<T> GetByIdAsync(int? id);

        Task AddAsync(T entity);

        Task<T> FindAsync(int? id);

        Task UpdateAsync(T newEntity);

        Task DeleteAsync(T removedEntity);

        bool CheckExists(int id);
    }
}
