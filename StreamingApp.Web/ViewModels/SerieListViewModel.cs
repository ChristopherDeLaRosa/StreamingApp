using StreamingApp.Data.Entities;
using System.Reflection.Metadata.Ecma335;

namespace StreamingApp.Web.ViewModels
{
    //ViewModel para listar las series en home
    public class SerieListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CoverImage { get; set; }
        public string Producer { get; set; }
        public string Genre { get; set; }
        //public Producer Producer { get; set; }
        //public Genre Genre { get; set; }


    }
}
