using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blogger.Web1.Models.ViewModels
{
    public class PostViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please upload an photo")]
        public IFormFile ImageFile { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string SelectedCategory { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
