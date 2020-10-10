using System;
using System.Linq;
using System.Threading.Tasks;
using Astro.API.Application.Clients;
using Astro.API.Application.Request.Post;
using Astro.API.Application.Response.Post;
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

        public async Task<UploadPostResult> UploadToBlobAsync(FileUploadRequestModel request)
        {
            try
            {
                foreach (var f in request.FormFiles)
                {
                    var blob = _blobClient.GetBlob(f.FileName);

                    using var file = f.OpenReadStream();
                    await blob.UploadFromStreamAsync(file);
                }

                return new UploadPostResult();
            }
            catch (Exception ex)
            {
                var fileNames = string.Join(";", request.FormFiles.Select(x => x.FileName));
                _log.Error(ex, $"Error during file uploads: {fileNames}");
                return new UploadPostResult(ex);
            }
        }
    }
}
