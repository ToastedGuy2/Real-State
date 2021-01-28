using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.CustomDataAnnotations;

namespace Web.ViewModels.Item
{
    public class AddItemViewModel : ItemViewModel
    {
        [Required(ErrorMessage = "Pick an Image")]
        public override IFormFile ImageUploaded { get; set; }
    }
}