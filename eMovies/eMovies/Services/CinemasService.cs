using eMovies.Base;
using eMovies.Data;
using eMovies.Models;
using Microsoft.EntityFrameworkCore;

namespace eMovies.Services
{
    public class CinemasService : EntityBaseRepositoryL<Cinema>, ICinemasService
    {
        public CinemasService(ApplicationDbContext context) 
            : base(context)
        {
        }

        public async Task<ICollection<Cinema>> GetAllCinemasAsync()
        {
            return await _context.Set<Cinema>().ToListAsync();
        }
    }
}
