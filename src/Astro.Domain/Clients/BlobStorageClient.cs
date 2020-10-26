using Astro.Abstractions.Clients;
using Astro.Infrastructure.Exceptions;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.IO;
using System.Threading.Tasks;

namespace Astro.Domain.Clients
{
    public class BlobStorageClient : IBlobStorageClient
    {
        private readonly BlobServiceClient _blobServiceClient;

        public BlobStorageClient(string connString)
        {
            _blobServiceClient = new BlobServiceClient(connString);
        }

        public async Task<Azure.Response<BlobContentInfo>> UploadAsync(
            Stream blobContent,
            string containerName,
            string blobName)
        {
            var serviceClient = _blobServiceClient.GetBlobContainerClient(containerName);

            var blobClient = serviceClient.GetBlobClient(blobName);

            if (await blobClient.ExistsAsync())
            {
                throw new ResourceConflictException(
                    $"Unable to upload content. {blobName} already exists. Try changing name of content.");
            }

            var uploadResult = await blobClient.UploadAsync(blobContent);

            return uploadResult;
        }
    }
}
