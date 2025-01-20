using eMovies.Base;
using eMovies.Data;
using eMovies.Models;

namespace eMovies.Services
{
    public class CinemasService : EntityBaseRepositoryL<Cinema>, ICinemasService
    {
        public CinemasService(ApplicationDbContext context) 
            : base(context)
        {
        }
    }
}
