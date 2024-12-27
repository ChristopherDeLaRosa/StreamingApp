using Microsoft.AspNetCore.Mvc.Rendering;
using StreamingApp.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace StreamingApp.Web.ViewModels
{
    public class SerieCreateViewModel
    {

        [Required(ErrorMessage = "You must enter the name")]
        [StringLength(100, ErrorMessage = "The name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must enter the Cover Image")]
        [StringLength(300, ErrorMessage = "The name cannot exceed 300 characters.")]
        [Url(ErrorMessage = "Must be a valid Image URL")]
        [Display(Name = "Cover Image")]
        public string CoverImage { get; set; }

        [Required(ErrorMessage = "You must enter the Video link (YouTube)")]
        [StringLength(500, ErrorMessage = "The name cannot exceed 500 characters.")]
        [Url(ErrorMessage = "Must be a valid YouTue URL")]
        [Display(Name = "YouTube Link")]
        public string VideoLink { get; set; }

        [Required(ErrorMessage = "You must select a Producer")]
        [Display(Name = "Producer")]
        public int ProducerId { get; set; }

        [Required(ErrorMessage = "You must select a Primary Genre")]
        [Display(Name = "Primary Genre")]
        public int PrimaryGenreId { get; set; }

        
        [Display(Name = "Secondary Genre")]
        public int SecondaryGenreId { get; set; }

        //listas para los selects
        public IEnumerable<SelectListItem> Producers { get; set; }
        public IEnumerable<SelectListItem> Genres { get; set; }

    }
}
