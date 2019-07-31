using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Astro.API.Application.Stores.EntityModels;
using Dapper;

namespace Astro.API.Application.Stores.CelestialObject
{
    public class CelestialObjectStore : ICelestialObjectStore
    {
        public async Task<CelestialObjectEntityModel> GetCelestialObject()
        {
            var sql = SqlLoader.GetSql(SqlResourceNames.CelestialObject.CelestialObject_Get);

            using (var conn = new SqlConnection(""))
            {
                await conn.OpenAsync();

                var result = await conn.QueryAsync<CelestialObjectEntityModel>(sql);

                return result.FirstOrDefault();
            }
        }
    }
}
