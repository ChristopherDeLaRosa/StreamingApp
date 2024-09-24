using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingApp.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StreamingAppContext _context;
        public ISerieRepository Series { get; private set; }

        public IProducerRepository Producers { get; private set; }

        public IGenreRepository Genres { get; private set; }

        public UnitOfWork(StreamingAppContext context)
        {
            _context = context;
            Series = new SerieRepository(_context);
            Producers = new ProducerRepository(_context);
            Genres = new GenreRepository(_context);

        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
