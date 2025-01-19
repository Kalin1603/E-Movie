using eMovies.Models;

namespace eMovies.Services
{
    public interface IProducersService
    {
        Task<ICollection<Producer>> GetAllProducersAsync();

        Task<Producer> GetProducerByIdAsync(int? id);

        Task CreateProducerAsync(Producer producer);

        Task<Producer> FindProducerAsync(int? id);

        Task UpdateProducerAsync(Producer newProducer);

        Task DeleteProducerAsync(Producer removedProducer);

        bool CheckProducerExists(int id);
    }
}
