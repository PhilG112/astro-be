namespace Astro.Application.Login.Queries.LoginUser
{
    public class LoginUserQuery : IQuery<string>
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}