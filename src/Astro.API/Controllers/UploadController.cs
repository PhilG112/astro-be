using Astro.API.Application.Services.Upload;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Astro.API.Controllers
{
    [ApiController]
    [Authorize]
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
        public async Task<IActionResult> Instagram()
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Blob()
        {
            throw new NotImplementedException();
        }
    }
}
