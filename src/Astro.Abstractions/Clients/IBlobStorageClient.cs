using Azure.Storage.Blobs.Models;
using System.IO;
using System.Threading.Tasks;

namespace Astro.Abstractions.Clients
{
    public interface IBlobStorageClient
    {
        /// <summary>
        /// Upload content to blob. E.g text files, photos
        /// </summary>
        /// <param name="blobContent">The stream containing the content.</param>
        /// <param name="containerName">The name of the container that will be uploaded to.</param>
        /// <param name="blobName">The name of the blob that will be created.</param>
        /// <returns><seealso cref="Azure.Response{BlobContentInfo}"/></returns>
        Task<Azure.Response<BlobContentInfo>> UploadAsync(Stream blobContent, string containerName, string blobName);
    }
}
