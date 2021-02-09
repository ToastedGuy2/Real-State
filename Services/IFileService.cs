using Microsoft.AspNetCore.Http;

namespace Services
{
    public interface IFileService
    {
        string UploadImage(IFormFile file);
        string DeleteImage(string imageName);
    }
}