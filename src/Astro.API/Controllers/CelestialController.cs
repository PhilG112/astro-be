using System.Threading.Tasks;
using Astro.API.Application.Request.Post;
using Astro.API.Application.Request.Update;
using Astro.API.Application.Stores.Celestial;
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
        private readonly ICelestialStore _store;

        public CelestialController(ICelestialStore store)
        {
            _store = store;
        }

        [HttpGet("{celestialObjectId}")]
        public async Task<IActionResult> GetCelestialObject(int celestialObjectId)
        {
            var result = await _store.GetCelestialObjectAsync(celestialObjectId);

            if (result.NotFound)
            {
                return NotFound();
            }

            if (result.HasException)
            {
                return StatusCode(500);
            }

            return Ok(result.Result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchCelestialObject([FromQuery]string text)
        {
            var result = await _store.SearchCelestialObjectAsync(text);

            if (result.NotFound)
            {
                return NotFound();
            }

            if (result.HasException)
            {
                return StatusCode(500);
            }

            return Ok(result.Results);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCelestialObject([FromBody]CelestialPostRequestModel request)
        {
            var result = await _store.CreateCelestialObjectAsync(request);

            if (result.HasException)
            {
                return StatusCode(500);
            }

            return Created($"/celestial/{result.Result}", result.Result);
        }

        [HttpPatch("{celestialObjectId}")]
        public async Task<IActionResult> UpdateCelestialObject(
            int celestialObjectId,
            [FromBody]CelestialUpdateRequestModel request)
        {
            var result = await _store.UpdateCelestialObjectAsync(request, celestialObjectId);

            if (result.HasException)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        [HttpDelete("{celestialObjectId}")]
        public async Task<IActionResult> DeleteCelestialObject(int celestialObjectId)
        {
            var result = await _store.DeleteCelestialObjectAsync(celestialObjectId);

            if (result.HasException)
            {
                return StatusCode(500);
            }

            return NoContent();
        }
    }
}