using Azure.Storage.Blobs.Models;

namespace ProductService.Interfaces.Services.Utilities
{
    public interface IBlobService
    {
        Task<string> Post(IFormFile imageFile);
    }
}
