
using Microsoft.AspNetCore.Mvc.Rendering;
using StreamingApp.Data.Entities;
using System.Reflection.Metadata.Ecma335;

namespace StreamingApp.Web.ViewModels
{
    public class HomeViewModel 
    {
        public List<SerieListViewModel> Series { get; set; }
        public IEnumerable<SelectListItem>  Producers { get; set; }
        public IEnumerable<SelectListItem>  Genres { get; set; }
        public Serie Serie { get; set; }
        public string Search { get; set; }
        public int? SelectedProducerId { get; set; }
        public int? SelectedGenreId { get; set; }
    }
}
