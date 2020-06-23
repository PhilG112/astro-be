namespace Astro.Application.DomainEntities
{
    public class User
    {
        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public string Salt { get; set; }
    }
}