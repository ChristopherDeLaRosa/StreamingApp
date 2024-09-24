using StreamingApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingApp.Data.Repositories
{
    public class ProducerRepository : Repository<Producer>, IProducerRepository
    {
        public ProducerRepository(StreamingAppContext context) : base(context)
        {
        }
    }
}
