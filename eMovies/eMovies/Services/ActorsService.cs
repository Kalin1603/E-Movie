using eMovies.Data;
using eMovies.Models;
using Microsoft.EntityFrameworkCore;

namespace eMovies.Services
{
    public class ActorsService : IActorsService
    {
        private readonly ApplicationDbContext _context;

        public ActorsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateActorAsync(Actor actor)
        {
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteActorAsync(Actor removedActor)
        {
            _context.Actors.Remove(removedActor);
            await _context.SaveChangesAsync();
        }

        public async Task<Actor> GetActorByIdAsync(int? id)
        {
            return await _context.Actors.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<ICollection<Actor>> GetAllActorsAsync()
        {
            var allActors = await _context.Actors.ToListAsync();
            return allActors;
        }

        public async Task<Actor> FindActorAsync(int? id)
        {
            return await _context.Actors.FindAsync(id);
        }

        public async Task UpdateActorAsync(Actor newActor)
        {
            _context.Update(newActor);
            await _context.SaveChangesAsync();
        }

        public bool CheckActorExists(int id)
        {
            return _context.Actors.Any(e => e.Id == id);
        }
    }
}
