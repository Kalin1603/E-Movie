using eMovies.Models;

namespace eMovies.Services
{
    public interface IActorsService
    {
        Task<ICollection<Actor>> GetAllActorsAsync();

        Task<Actor> GetActorByIdAsync(int? id);

        Task CreateActorAsync(Actor actor);

        Task<Actor> FindActorAsync(int? id);

        Task UpdateActorAsync(Actor newActor);

        Task DeleteActorAsync(Actor removedActor);

        bool CheckActorExists (int id);
    }
}
