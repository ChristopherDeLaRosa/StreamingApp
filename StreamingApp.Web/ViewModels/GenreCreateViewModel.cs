using System.ComponentModel.DataAnnotations;

namespace StreamingApp.Web.ViewModels
{
    public class GenreCreateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You must enter the name")]
        [StringLength(50, ErrorMessage = "The name cannot exceed 50 characters")]
        [Display(Name = "Name of Genre")]
        public string Name { get; set; }
    }
}
