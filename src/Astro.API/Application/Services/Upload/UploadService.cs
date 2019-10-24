using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Astro.API.Application.Clients;
using Astro.API.Application.Request.Post;
using Serilog;

namespace Astro.API.Application.Services.Upload
{
    public class UploadService : IUploadService
    {
        private readonly BlobStorageClient _blobClient;
        private readonly ILogger _log = Log.ForContext<UploadService>();

        public UploadService(BlobStorageClient blobClient)
        {
            _blobClient = blobClient;
        }

        public Task UploadToBlobAsync(FileUploadRequestModel request)
        {
            throw new NotImplementedException();
        }
    }
}
