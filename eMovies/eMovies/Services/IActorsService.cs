using eMovies.Base;
using eMovies.Models;

namespace eMovies.Services
{
    public interface IActorsService : IEntityBaseRepository<Actor>
    {
        Task<ICollection<Actor>> GetAllActorsAsync();
    }
}
