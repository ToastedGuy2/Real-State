using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.CustomDataAnnotations;

namespace Web.ViewModels.House
{
    public class HouseViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; } = 200;

        [Required(ErrorMessage = "Bedrooms is required")]
        public int Bedrooms { get; set; } = 1;
        [Required(ErrorMessage = "Bathrooms is required")]
        public int Bathrooms { get; set; } = 1;
        [Required(ErrorMessage = "Size is required")]
        public double Size { get; set; } = 225;
        public SelectList Provinces { get; set; }
        [Display(Name = "Province")]
        [Required(ErrorMessage = " Pick a Province")]
        public int ProvinceId { get; set; }
        [Display(Name = "Image")]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" },
                    ErrorMessage = "Your image's filetype is not valid.")]
        public virtual IFormFile ImageUploaded { get; set; }
        [Required]
        [MinLength(50, ErrorMessage = "The description should include at least 50 characters")]
        [MaxLength(255, ErrorMessage = "Is too long, 255 characters is the maximum")]
        public string Description { get; set; }
        public IEnumerable<Feature> Features { get; set; } = new List<Feature>();
        public IEnumerable<HouseFeature> SelectedFeatures { get; set; } = new List<HouseFeature>();
        public IEnumerable<Service> Services { get; set; } = new List<Service>();
        public IEnumerable<HouseService> SelectedServices { get; set; } = new List<HouseService>();
    }
}