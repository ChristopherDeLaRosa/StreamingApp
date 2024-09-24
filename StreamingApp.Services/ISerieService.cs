using StreamingApp.Data.Entities;


namespace StreamingApp.Services
{
    public interface ISerieService
    {
        Task<IEnumerable<Serie>> GetAllSeriesAsync();
        Task<Serie> GetSerieByIdAsync(int id);
        Task<IEnumerable<Serie>> SearchSeriesByNameAsync(string name);
        Task<IEnumerable<Serie>> FilterSeriesByProducerAsync(int producerId);
        Task<IEnumerable<Serie>> FilterSeriesByGenreAsync(int genreId);
        Task AddSerieAsync(Serie serie);
        Task UpdateSerieAsync(Serie serie);
        Task DeleteSerieAsync(int id);
    }
}
