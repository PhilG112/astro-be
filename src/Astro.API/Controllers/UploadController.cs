using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Astro.API.Application.Request.Post;
using Astro.API.Application.Services.Upload;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Astro.API.Controllers
{
    [ApiController]
    [Route("upload")]
    [Produces("application/json")]
    public class UploadController : Controller
    {
        private readonly IUploadService _uploadService;

        public UploadController(IUploadService uploadService)
        {
            _uploadService = uploadService;
        }

        [HttpPost("instagram")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Instagram(IEnumerable<IFormFile> files)
        {
            throw new NotImplementedException();
        }

        [HttpPost("flickr")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Flickr()
        {
            throw new NotImplementedException();
        }

        [HttpPost("blob")]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Blob([FromForm]FileUploadRequestModel request)
        {
            var result = await _uploadService.UploadToBlobAsync(request);

            if (result.HasException)
            {
                return StatusCode(500);
            }

            return Created("/upload/blob", null);
        }
    }
}
