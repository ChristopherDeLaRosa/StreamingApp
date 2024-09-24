using StreamingApp.Data.Entities;
using StreamingApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingApp.Services
{
    public class SerieService : ISerieService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SerieService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Serie>> GetAllSeriesAsync()
        {
            return await _unitOfWork.Series
                .GetAllAsync()
                .ContinueWith(t => t.Result);
        }

        public async Task<Serie> GetSerieByIdAsync(int id)
        {
            return await _unitOfWork.Series.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Serie>> SearchSeriesByNameAsync(string name)
        {
            return await _unitOfWork.Series.FindAsync(s => s.Name == name);//verificar
        }

        public async Task<IEnumerable<Serie>> FilterSeriesByProducerAsync(int producerId)
        {
            return await _unitOfWork.Series.FindAsync(s => s.ProducerId == producerId);//verificar
        }

        public async Task<IEnumerable<Serie>> FilterSeriesByGenreAsync(int genreId)
        {
            return await _unitOfWork.Series.FindAsync(s => 
            s.PrimaryGenreId == genreId || s.SecondaryGenreId == genreId);
        }

        public async Task AddSerieAsync(Serie serie)
        {
            await _unitOfWork.Series.AddAsyc(serie);
            await _unitOfWork.CompleteAsync();

        }       

        public async Task UpdateSerieAsync(Serie serie)
        {
            _unitOfWork.Series.Update(serie);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteSerieAsync(int id)
        {
            var serie = await _unitOfWork.Series.GetByIdAsync(id);
            if (serie != null)
            {
                _unitOfWork.Series.Remove(serie);
                await _unitOfWork.CompleteAsync();
            }
        }
    }
}
