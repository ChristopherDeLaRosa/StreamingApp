using StreamingApp.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingApp.Data.Entities
{
    public class Genre : BaseBasicEntity
    {
        // Navigation Properties
        public ICollection<Serie> PrimarySeries { get; set; }
        public ICollection<Serie> SecondarySeries { get; set; }
    }
}
