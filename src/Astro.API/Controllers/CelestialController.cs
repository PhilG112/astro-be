using System;
using System.Threading.Tasks;
using Astro.API.Application.Stores.CelestialObject;
using Astro.API.Application.Stores.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace Astro.API.Controllers
{
    [Produces("application/json")]
    [Route("celestial")]
    public class CelestialController : Controller
    {
        private readonly ICelestialObjectStore _store;

        public CelestialController(ICelestialObjectStore store)
        {
            _store = store;
        }

        [HttpGet("get")]
        [ProducesResponseType(typeof(CelestialObjectEntityModel), 200)]
        public async Task<IActionResult> GetCelestialObject()
        {
            var result = await _store.GetCelestialObject();

            return Ok(result);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
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