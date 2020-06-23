using System.Data;

namespace Astro.Abstractions.Data
{
    public interface ISqlConnectionFactory
    {
        IDbConnection CreateOpenConnection();
    }
}