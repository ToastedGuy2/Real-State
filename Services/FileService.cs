using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
namespace Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _env;

        public FileService(IWebHostEnvironment env)
        {
            _env = env ?? throw new ArgumentNullException(nameof(env)); ;
        }

        public string DeleteImage(string imageName)
        {
            throw new NotImplementedException();
        }

        public string UploadImage(IFormFile file)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }
            var uploadDirectory = "images/Items";
            var uploadPath = Path.Combine(_env.WebRootPath, uploadDirectory);

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var fileName = $"{file.Name}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(uploadPath, fileName);

            using (var stream = File.Create(filePath))
            {
                file.CopyTo(stream);
            }

            return fileName;
        }
    }
}