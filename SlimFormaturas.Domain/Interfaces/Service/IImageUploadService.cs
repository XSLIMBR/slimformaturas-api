using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SlimFormaturas.Domain.Interfaces.Service {
    public interface IImageUploadService {
        Task<string> SingleFile(string uploadDir, IFormFile file);
        string MultipleFiles(string uploadDir, IEnumerator<IFormFile> files);
    }
}
