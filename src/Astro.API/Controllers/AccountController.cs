using System.Threading.Tasks;
using Astro.API.Application.Auth;
using Astro.API.Application.Request.Post;
using Microsoft.AspNetCore.Mvc;

namespace Astro.API.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogInManager _logInManager;

        public AccountController(ILogInManager logInManager)
        {
            _logInManager = logInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginRequestModel request)
        {
            var result = await _logInManager.LogIn(request.UserName, request.Password);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(new { Token = result });
        }
    }
}
