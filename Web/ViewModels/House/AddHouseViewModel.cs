using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.CustomDataAnnotations;

namespace Web.ViewModels.House
{
    public class AddHouseViewModel : HouseViewModel
    {
        [Required(ErrorMessage = "Pick an Image")]
        public override IFormFile ImageUploaded { get; set; }
    }
}