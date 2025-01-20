
using eMovies.Data;
using eMovies.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eMovies.Base
{
    public class EntityBaseRepositoryL<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        protected readonly ApplicationDbContext _context;

        public EntityBaseRepositoryL(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CheckExists(int id)
        {
            return _context.Set<T>().Any(e => e.Id == id);
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T removedEntity)
        {
            _context.Set<T>().Remove(removedEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> FindAsync(int? id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            var all = await _context.Set<T>().ToListAsync();
            return all;
        }

        public async Task<T> GetByIdAsync(int? id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateAsync(T newEntity)
        {
            _context.Update(newEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Movie>> GetAllMoviesAsync()
        {
            var movies = await _context.Movies.Include(m => m.Cinema).Include(m => m.Producer).OrderBy(m => m.Title).ToListAsync();
            return movies;
        }

        public async Task<Movie> GetMovieByIdAsync(int? id)
        {
            return await _context.Movies.Include(m => m.Cinema).Include(m => m.Producer).FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
