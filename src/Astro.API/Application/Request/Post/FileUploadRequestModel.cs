using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Astro.API.Application.Request.Post
{
    public class FileUploadRequestModel
    {
        public IList<IFormFile> FormFiles { get; set; }

        public string Description { get; set; }
    }
}
