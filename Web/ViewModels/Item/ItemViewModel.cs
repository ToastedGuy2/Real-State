using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.CustomDataAnnotations;

namespace Web.ViewModels.Item
{
    public class ItemViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [RegularExpression(@"[0-9]+(\.[0-9][0-9]?)?",
                             ErrorMessage = "It's not a valid price")]
        public double Price { get; set; }
        public SelectList Categories { get; set; }
        [Display(Name = "Category")]
        [Required(ErrorMessage = " Pick a Category")]
        public int CategoryId { get; set; }
        public SelectList Brands { get; set; }
        [Display(Name = "Brand")]
        [Required(ErrorMessage = " Pick a Brand")]
        public int BrandId { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Display(Name = "Image")]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" },
                    ErrorMessage = "Your image's filetype is not valid.")]
        public virtual IFormFile ImageUploaded { get; set; }
        public string ImageName { get; set; }
    }
}