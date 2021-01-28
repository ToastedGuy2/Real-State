using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Web.CustomDataAnnotations
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;

        public AllowedExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }


        public override bool IsValid(object value)
        {
            if (value is null)
                return true;

            var file = value as IFormFile;
            var extension = Path.GetExtension(file.FileName);

            if (!_extensions.Contains(extension.ToLower()))
                return false;

            return true;
        }
    // }
    // protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    // {
    //     var file = value as IFormFile;
    //     var extension = Path.GetExtension(file.FileName);
    //     if (file != null)
    //     {
    //         if (!_extensions.Contains(extension.ToLower()))
    //         {
    //             return new ValidationResult(GetErrorMessage());
    //         }
    //     }
    //
    //     return ValidationResult.Success;
    // }

    // public string GetErrorMessage()
    // {
    //     return $"Your image's filetype is not valid.";
    // }
}

}