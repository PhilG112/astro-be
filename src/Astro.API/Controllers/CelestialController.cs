using System;
using System.Threading.Tasks;
using Astro.API.Application.Request.Post;
using Astro.API.Application.Stores.Celestial;
using Microsoft.AspNetCore.Mvc;

namespace Astro.API.Controllers
{
    [Produces("application/json")]
    [Route("celestial")]
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
            var result = await _store.GetCelestialObject(id);

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
            var result = await _store.SearchCelestialObject(text);

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
        public async Task<IActionResult> CreateCelestialObject(CelestialPostRequestModel request)
        {
            var result = await _store.CreateCelestialObject(request);

            throw new NotImplementedException();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateCelestialObject()
        {
            throw new NotImplementedException();
        }
    }
}