using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace DPRSolution.Service
{
    public class FileUploadService
    {
        public async Task UploadFile(IFormFile file, string fileName)
        {
            if (file != null && file.Length > 0)
            {


                using Stream fileStream = new FileStream(fileName, FileMode.Create);
                await file.CopyToAsync(fileStream);
            }
        }
    }
}
