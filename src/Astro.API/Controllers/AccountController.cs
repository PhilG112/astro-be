using System.Threading.Tasks;
using Astro.API.Application.Auth;
using Astro.API.Application.Request.Post;
using Microsoft.AspNetCore.Mvc;

namespace Astro.API.Controllers
{
    [ApiController]
    public class AccountController : Controller
    {
        private readonly ILogInManager _logInManager;

        public AccountController(ILogInManager logInManager)
        {
            _logInManager = logInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LogInRequestModel request)
        {
            var result = await _logInManager.LogIn(request.UserName, request.Password);

            if (result.HasException)
            {
                return StatusCode(500);
            }

            if (result.NotFound)
            {
                return BadRequest();
            }

            return Ok(result.Result);
        }
    }
}
