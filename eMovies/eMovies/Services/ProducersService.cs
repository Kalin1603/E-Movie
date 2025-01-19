using eMovies.Data;
using eMovies.Models;
using Microsoft.EntityFrameworkCore;

namespace eMovies.Services
{
    public class ProducersService : IProducersService
    {
        private readonly ApplicationDbContext _context;

        public ProducersService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CheckProducerExists(int id)
        {
            return _context.Producers.Any(e => e.Id == id);
        }

        public async Task CreateProducerAsync(Producer producer)
        {
            await _context.Producers.AddAsync(producer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProducerAsync(Producer removedProducer)
        {
            _context.Producers.Remove(removedProducer);
            await _context.SaveChangesAsync();
        }

        public async Task<Producer> FindProducerAsync(int? id)
        {
            return await _context.Producers.FindAsync(id);
        }

        public async Task<ICollection<Producer>> GetAllProducersAsync()
        {
            var allProducers = await _context.Producers.ToListAsync();
            return allProducers;
        }

        public async Task<Producer> GetProducerByIdAsync(int? id)
        {
            return await _context.Producers.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateProducerAsync(Producer newProducer)
        {
            _context.Update(newProducer);
            await _context.SaveChangesAsync();
        }
    }
}
