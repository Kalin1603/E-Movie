using eMovies.Base;
using eMovies.Data;
using eMovies.Models;
using Microsoft.EntityFrameworkCore;

namespace eMovies.Services
{
    public class ProducersService : EntityBaseRepositoryL<Producer>, IProducersService
    {
        public ProducersService(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<ICollection<Producer>> GetAllProducersAsync()
        {
            return await _context.Set<Producer>().ToListAsync();
        }
    }
}
