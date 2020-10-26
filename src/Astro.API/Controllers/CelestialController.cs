using System.Threading.Tasks;
using Astro.Application.Celestial.Commands.CreateCelestialObject;
using Astro.Application.Celestial.Commands.DeleteCelestialObject;
using Astro.Application.Celestial.Commands.UpdateCelestialObject;
using Astro.Application.Celestial.Queries.GetCelestialById;
using Astro.Application.Celestial.Queries.SearchCelestial;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Astro.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("celestial")]
    [ApiController]
    public class CelestialController : Controller
    {
        private IMediator _mediator;

        public CelestialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{celestialObjectId}")]
        public async Task<IActionResult> GetCelestialObject(int celestialObjectId)
        {
            var result = await _mediator.Send(new GetCelestialByIdQuery(celestialObjectId));

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchCelestialObject([FromQuery]string text)
        {
            var result = await _mediator.Send(new SearchCelestialQuery(text));

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCelestialObject([FromBody]CreateCelestialObjectCommand request)
        {
            var result = await _mediator.Send(request);

            return Created($"/celestial/{result}", new { CelestialObjectId = result });
        }

        [HttpPatch("{celestialObjectId}")]
        public async Task<IActionResult> UpdateCelestialObject(
            int celestialObjectId,
            [FromBody]UpdateCelestialObjectCommand request)
        {
            request.Id = celestialObjectId;

            await _mediator.Send(request);

            return NoContent();
        }

        [HttpDelete("{celestialObjectId}")]
        public async Task<IActionResult> DeleteCelestialObject(int celestialObjectId)
        {
            await _mediator.Send(new DeleteCelestialObjectCommand(celestialObjectId));

            return NoContent();
        }
    }
}