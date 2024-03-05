using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using ProductService.Interfaces.Services.Utilities;

namespace ProductService.Service.Utlities
{
    public class BlobService:IBlobService
    {
        BlobServiceClient _blobClient;
        BlobContainerClient _containerClient;
        string azureConnectionString = "DefaultEndpointsProtocol=https;AccountName=microecom;AccountKey=pztxL5NbKALGbnHIW7pvsHdwQUHOyVA18p6zMXPVdajBqKYfLPlEVsit/+kuexnf1XMHztcUPCjb+AStfFjX1w==;EndpointSuffix=core.windows.net";

        public BlobService()
        {
            _blobClient = new BlobServiceClient(azureConnectionString);
            _containerClient = _blobClient.GetBlobContainerClient("pictures");
        }
        public async Task<string> Post(IFormFile imageFile)
        {
           
            string fileName = Guid.NewGuid().ToString() + ".png";

            using (var memoryStream = new MemoryStream())
            {
                await imageFile.CopyToAsync(memoryStream);
                memoryStream.Position = 0;
                Azure.Response<BlobContentInfo> response = await _containerClient.UploadBlobAsync(fileName, memoryStream, default);
                return _containerClient.GetBlobClient(fileName).Uri.ToString();
            }

        }

    }
}
