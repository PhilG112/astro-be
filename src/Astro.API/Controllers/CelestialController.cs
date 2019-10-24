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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCelestialObject(int id)
        {
            var result = await _store.GetCelestialObjectAsync(id);

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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCelestialObject([FromBody]CelestialPostRequestModel request)
        {
            var result = await _store.CreateCelestialObjectAsync(request);

            if (result.HasException)
            {
                return StatusCode(500);
            }

            return Created($"/celestial/{result.Result}", result.Result);
        }

        [HttpPatch]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCelestialObject([FromBody]CelestialUpdateRequestModel request)
        {
            var result = await _store.UpdateCelestialObjectAsync(request);

            if (result.HasException)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCelestialObject(int id)
        {
            var result = await _store.DeleteCelestialObjectAsync(id);

            if (result.HasException)
            {
                return StatusCode(500);
            }

            return NoContent();
        }
    }
}