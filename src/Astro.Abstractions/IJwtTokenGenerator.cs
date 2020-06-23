namespace Astro.Abstractions
{
    public interface IJwtTokenGenerator
    {
        string CreateJwtToken();
    }
}