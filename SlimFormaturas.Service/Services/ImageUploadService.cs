using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SlimFormaturas.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SlimFormaturas.Service.Services {
    public class ImageUploadService : IImageUploadService {
        private readonly IWebHostEnvironment _hostingEnv;
        public ImageUploadService(IWebHostEnvironment hostingEnv) {
            _hostingEnv = hostingEnv;
        }

        public string MultipleFiles(string uploadDir, IEnumerator<IFormFile> files) {
            throw new NotImplementedException();
        }

        public async Task<string> SingleFile(string uploadDir, IFormFile file) {

            //var uploadDir = "Uploads/Images/Profile";
            var uploadPath = Path.Combine(_hostingEnv.WebRootPath, uploadDir);

            if (!Directory.Exists(uploadPath)) {
                Directory.CreateDirectory(uploadPath);
            }

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadPath, fileName);

            using (var stream = File.Create(filePath)) {
                await file.CopyToAsync(stream);
            }

            return uploadDir + fileName;
        }
    }
}
