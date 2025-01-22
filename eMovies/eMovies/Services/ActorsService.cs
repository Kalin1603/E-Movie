using eMovies.Base;
using eMovies.Data;
using eMovies.Models;
using Microsoft.EntityFrameworkCore;

namespace eMovies.Services
{
    public class ActorsService : EntityBaseRepositoryL<Actor>, IActorsService
    {
        public ActorsService(ApplicationDbContext context)
            : base(context)
        {

        }
        public async Task<ICollection<Actor>> GetAllActorsAsync()
        {
            return await _context.Set<Actor>().ToListAsync();
        }
    }
}
