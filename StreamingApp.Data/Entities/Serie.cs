using StreamingApp.Data.Common;
using System.ComponentModel.DataAnnotations;


namespace StreamingApp.Data.Entities
{
    public class Serie : BaseBasicEntity
    {
        public string CoverImage { get; set; }
        public string VideoLink { get; set; }

        //Navigation Properties
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }

        public int PrimaryGenreId { get; set; }
        public Genre PrimaryGenre { get; set; }

        public int SecondaryGenreId { get; set; }
        public Genre SecondaryGenre { get; set; }

    }
}
