namespace Astro.Application.Auth
{
    public class AppSettings
    {
        public string SecretKey { get; set; }

        public int ExpiresInHours { get; set; }
    }

}