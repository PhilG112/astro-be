using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace Astro.API.Application.Clients
{
    public class BlobStorageClient
    {
        private readonly CloudBlobClient _cloudBlobClient;
        private readonly CloudBlobContainer _cloudBlobContainer;

        public BlobStorageClient(string connString)
        {
            if (CloudStorageAccount.TryParse(connString, out CloudStorageAccount storageAccount))
            {
                _cloudBlobClient = storageAccount.CreateCloudBlobClient();
                _cloudBlobContainer = _cloudBlobClient
                    .GetContainerReference("astrophotosblob");
            }
        }

        public CloudBlockBlob GetBlob(string blobName)
        {
            return _cloudBlobContainer.GetBlockBlobReference(blobName);
        }

        public IEnumerable<Task> InitBlob()
        {
            var permissions = new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Off
            };

            yield return _cloudBlobContainer.CreateIfNotExistsAsync();
            yield return _cloudBlobContainer.SetPermissionsAsync(permissions);
        }
    }
}
