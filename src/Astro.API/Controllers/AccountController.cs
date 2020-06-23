using System.Threading.Tasks;
using Astro.API.Application.Request.Login;
using Astro.Application.Login.Queries.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Astro.API.Controllers
{
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LogInRequestModel request)
        {
            var result = await _mediator.Send(
                new LoginUserQuery { UserName = request.UserName, Password = request.Password });

            return Ok(new { Token = result });
        }
    }
}
