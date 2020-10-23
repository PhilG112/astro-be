using System;
using System.Threading.Tasks;
using Astro.API.Application.Request.Post;
using Astro.API.Application.Services.Upload;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Astro.API.Controllers
{
    [ApiController]
    [Route("upload")]
    [Produces("application/json")]
    [Authorize]
    public class UploadController : Controller
    {
        private readonly IUploadService _uploadService;

        public UploadController(IUploadService uploadService)
        {
            _uploadService = uploadService;
        }

        [HttpPost("flickr")]
        public async Task<IActionResult> Flickr()
        {
            throw new NotImplementedException();
        }

        [HttpPost("blob")]
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
