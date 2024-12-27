using Microsoft.EntityFrameworkCore;
using StreamingApp.Data.Entities;
using StreamingApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreamingApp.Data;

namespace StreamingApp.Services
{
	public class SerieService : ISerieService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly StreamingAppContext _context;

		public SerieService(IUnitOfWork unitOfWork, StreamingAppContext context)
		{
			_unitOfWork = unitOfWork;
			_context = context;
		}

		public async Task<IEnumerable<Serie>> GetAllSeriesAsync()
		{
			
			return await _context.Series
			.Include(s => s.Producer)
			.Include(s => s.PrimaryGenre)
			.Include(s => s.SecondaryGenre)
			.ToListAsync();
		}

		public async Task<Serie> GetSerieByIdAsync(int id)
		{

			return await _context.Series
				   .Include(s => s.Producer)
				   .Include(s => s.PrimaryGenre)
				   .Include(s => s.SecondaryGenre)
				   .FirstOrDefaultAsync(s => s.Id == id);

		}

		public async Task<IEnumerable<Serie>> SearchSeriesByNameAsync(string name)
		{
			//return await _unitOfWork.Series.FindAsync(s => s.Name == name);//verificar
			return await _unitOfWork.Series.FindAsync(s => s.Name.Contains(name));

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
			await _unitOfWork.Series.AddAsync(serie);
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
