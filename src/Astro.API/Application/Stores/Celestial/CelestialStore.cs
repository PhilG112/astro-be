using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Astro.API.Application.Extensions;
using Astro.API.Application.Response;
using Astro.API.Application.Stores.EntityModels;
using Dapper;
using Serilog;

namespace Astro.API.Application.Stores.Celestial
{
    public class CelestialStore : ICelestialStore
    {
        private readonly string _connString;

        private readonly ILogger _log = Log.ForContext<CelestialStore>();

        public CelestialStore(string connString)
        {
            _connString = connString;
        }

        public async Task<CelestialGetResult> GetCelestialObject()
        {
            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    await conn.OpenAsync();

                    var celestialObject = await conn.QueryFirstOrDefaultAsync<CelestialEntityModel>(
                        SqlLoader.GetSql(SqlResourceNames.CelestialObjects.CelestialObject_Get),
                        new { Id = 2 });

                    if (celestialObject == null)
                    {
                        return new CelestialGetResult(notFound: true);
                    }

                    var distances = await conn.QueryAsync<DistanceEntityModel>(
                        SqlLoader.GetSql(SqlResourceNames.Distances.Distances_Get),
                        new { @CelestialObjectId = celestialObject.Id });

                    celestialObject.Distances = distances.ToList();

                    return new CelestialGetResult(celestialObject.ToResponseModel());
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex, "Unable to load entity from database");
                return new CelestialGetResult(ex);
            }
        }
    }
}
