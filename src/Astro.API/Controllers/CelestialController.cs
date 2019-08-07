using System;
using System.Threading.Tasks;
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

        [HttpGet]
        public async Task<IActionResult> GetCelestialObject()
        {
            var result = await _store.GetCelestialObject();

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

        [HttpPost]
        public async Task<IActionResult> CreateCelestialObject()
        {
            throw new NotImplementedException();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateCelestialObject()
        {
            throw new NotImplementedException();
        }
    }
}