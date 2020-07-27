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

        public async Task<string> SingleFile(string uploadDir, string file) {

            var uploadPath = Path.Combine(_hostingEnv.WebRootPath, uploadDir);

            if (!Directory.Exists(uploadPath)) {
                Directory.CreateDirectory(uploadPath);
            }

            var fileName = "";

            if (file.Contains("data:image/png;base64")) {
                var newFile = file.Replace("data:image/png;base64,", "");
                var imageBytes = Convert.FromBase64String(newFile);
                fileName = Guid.NewGuid() + ".png";

                string filepath = Path.Combine(uploadPath, fileName);

                if (imageBytes.Length > 0) {
                    using (var stream = new FileStream(filepath, FileMode.Create)) {
                        await stream.WriteAsync(imageBytes, 0, imageBytes.Length);
                        stream.Flush();
                    }
                }

            } else if (file.Contains("data:image/jpeg;base64,")) {
                var newFile = file.Replace("data:image/jpeg;base64,", "");
                var imageBytes = Convert.FromBase64String(newFile);
                fileName = Guid.NewGuid() + ".jpeg";

                string filepath = Path.Combine(uploadPath, fileName);

                if (imageBytes.Length > 0) {
                    using (var stream = new FileStream(filepath, FileMode.Create)) {
                        await stream.WriteAsync(imageBytes, 0, imageBytes.Length);
                        stream.Flush();
                    }
                }
            }

            return uploadDir + fileName;
        }
    }
}
