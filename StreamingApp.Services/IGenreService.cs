using StreamingApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingApp.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<Genre>> GetAllGenreAsync();
        Task<Genre> GetGenreByIdAsync(int id);
        Task AddGenreAsync(Genre genre);
        Task UpdateGenreAsync(Genre genre);
        Task DeleteGenreAsync(int id);
    }
}
