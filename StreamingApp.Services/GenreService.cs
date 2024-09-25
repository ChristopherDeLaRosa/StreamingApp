using StreamingApp.Data.Entities;
using StreamingApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingApp.Services
{
    public class GenreService : IGenreService
    {

        private readonly IUnitOfWork _unitOfWork;
        public GenreService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Genre>> GetAllGenreAsync()
        {
            return await _unitOfWork.Genres.GetAllAsync();
        }

        public async Task<Genre> GetGenreByIdAsync(int id)
        {
            return await _unitOfWork.Genres.GetByIdAsync(id);
        }

        public async Task AddGenreAsync(Genre genre)
        {
            await _unitOfWork.Genres.AddAsync(genre);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateGenreAsync(Genre genre)
        {
            _unitOfWork.Genres.Update(genre);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteGenreAsync(int id)
        {
            var genre = await _unitOfWork.Genres.GetByIdAsync(id);

            if(genre != null)
            {
                _unitOfWork.Genres.Remove(genre);
                await _unitOfWork.CompleteAsync();
            }
        }

        
    }
}
