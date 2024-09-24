using System.ComponentModel.DataAnnotations;

namespace StreamingApp.Web.ViewModels
{
    public class ProducerCreateViewModel
    {
        [Required(ErrorMessage = "You must enter the name")]
        [StringLength(100, ErrorMessage = "The name cannot exceed 100 characters.")]
        [Display(Name = "Name of the Producer")]
        public string Name { get; set; }

    }
}
