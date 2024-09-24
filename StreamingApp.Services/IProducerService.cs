using StreamingApp.Data.Entities;

namespace StreamingApp.Services
{
    public interface IProducerService
    {
        Task<IEnumerable<Producer>> GetAllProducersAsync();
        Task<Producer> GetProducersByIdAsync(int id);
        Task AddProducerAsync(Producer producer);
        Task UpdateProducerAsync(Producer producer);
        Task DeleteProducerAsync(int id);
    }
}
