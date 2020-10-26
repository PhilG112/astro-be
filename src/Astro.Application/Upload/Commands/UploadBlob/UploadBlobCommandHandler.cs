using Astro.Abstractions.Clients;
using Astro.Application.Upload.Commands.Dtos;
using MediatR;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Astro.Application.Upload.Commands.UploadBlob
{
    public class UploadBlobCommandHandler : ICommandHandler<UploadBlobCommand, IEnumerable<UploadBlobDto>>
    {
        private readonly IBlobStorageClient _blobStorageClient;

        public UploadBlobCommandHandler(IBlobStorageClient blobStorageClient)
        {
            _blobStorageClient = blobStorageClient;
        }

        public async Task<IEnumerable<UploadBlobDto>> Handle(
            UploadBlobCommand request,
            CancellationToken cancellationToken)
        {
            var result = new List<UploadBlobDto>();

            foreach (var file in request.FormFiles)
            {
                using var fileStream = file.OpenReadStream();

                var response = await _blobStorageClient.UploadAsync(fileStream, "astrophotosblob", file.FileName);

                result.Add(new UploadBlobDto
                {
                    StatusCode = response.GetRawResponse().Status,
                    FileName = file.FileName
                });
            }

            return result;
        }
    }
}
