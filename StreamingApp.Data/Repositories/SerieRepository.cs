using StreamingApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingApp.Data.Repositories
{
    public class SerieRepository : Repository<Serie>, ISerieRepository
    {
        //usa :base(context) para llamar al constructor de la clase base (repository<serie>), pasandole el contexto
        public SerieRepository(StreamingAppContext context) : base(context)
        {
        }
    }
}
