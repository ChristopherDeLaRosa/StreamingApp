
using StreamingApp.Data.Common;

namespace StreamingApp.Data.Entities
{
    public class Producer : BaseBasicEntity
    {
        public ICollection<Serie> Series { get; set; }

    }
}
