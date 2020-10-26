using Astro.Application.Upload.Commands.Dtos;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Astro.Application.Upload.Commands.UploadBlob
{
    public class UploadBlobCommand : ICommand<IEnumerable<UploadBlobDto>>
    {
        public IEnumerable<IFormFile> FormFiles { get; set; }

        public string Description { get; set; }
    }
}
