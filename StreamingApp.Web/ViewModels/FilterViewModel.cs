using Microsoft.AspNetCore.Mvc.Rendering;
using StreamingApp.Data.Entities;

namespace StreamingApp.Web.ViewModels
{
    public class FilterViewModel 
    {

        public IEnumerable<SelectListItem> Producers { get; set; }
        public IEnumerable<SelectListItem> Genres { get; set; }
        public List<SerieListViewModel> Series { get; set; }
        public string Search { get; set; }
        public int? SelectedProducerId { get; set; }
        public int? SelectedGenreId { get; set; }
    }
}
