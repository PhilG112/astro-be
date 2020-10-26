using System;
using System.Threading.Tasks;
using Astro.Application.Upload.Commands.UploadBlob;
using MediatR;
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
        private readonly IMediator _mediator;

        public UploadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("flickr")]
        public async Task<IActionResult> Flickr()
        {
            throw new NotImplementedException();
        }

        [HttpPost("blob")]
        public async Task<IActionResult> Blob([FromForm]UploadBlobCommand request)
        {
            var result = await _mediator.Send(request);

            return Created("/download/blobs", result);
        }
    }
}
