using System.Threading.Tasks;

namespace Astro.API.Application.Auth
{
    public interface ILogInManager
    {
        Task<string> LogIn(string userName, string password);
    }
}