using Astro.API.Application.Response.LogIn;
using System.Threading.Tasks;

namespace Astro.API.Application.Auth
{
    public interface ILogInManager
    {
        Task<LogInRequestResult> LogIn(string userName, string password);
    }
}