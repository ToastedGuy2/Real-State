using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.ViewModels.Home
{
    public class IndexViewModel
    {
        [Required]
        public string SelectedProvince { get; set; }
        public SelectList Provinces { get; set; }
    }
}