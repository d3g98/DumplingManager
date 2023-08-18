using Microsoft.AspNetCore.Http;

namespace DumplingManager.Application.Service.Utils
{
    public interface IFileService
    {
        public string Upload(string folder, IFormFile file);
    }
}