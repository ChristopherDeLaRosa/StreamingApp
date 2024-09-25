using StreamingApp.Data.Entities;

namespace StreamingApp.Web.ViewModels
{
    public class DetailsSerieViewModel
    {
        public Serie Serie { get; set; }
        public Producer Producer { get; set; }
        public Genre PrimaryGenre { get; set; }
        public Genre? SecondaryGenre { get; set; }
		public string FullVideoUrl
		{
			get
			{
				if (string.IsNullOrEmpty(Serie.VideoLink))
				{
					return string.Empty;
				}
				//para convertir el enlace de YouTube en el formato de embed
				return Serie.VideoLink.Replace("watch?v=", "embed/");
			}
		}
	}
}
