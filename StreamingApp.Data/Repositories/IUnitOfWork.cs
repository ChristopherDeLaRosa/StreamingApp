using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingApp.Data.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ISerieRepository Series {  get; }
        IProducerRepository Producers { get; }
        IGenreRepository Genres { get; }
        Task<int> CompleteAsync();

    }
}
