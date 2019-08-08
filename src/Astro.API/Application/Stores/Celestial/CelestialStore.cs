using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Astro.API.Application.Extensions;
using Astro.API.Application.Request.Post;
using Astro.API.Application.Response.Get;
using Astro.API.Application.Response.Search;
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

        public async Task<CelestialGetResult> GetCelestialObject(int id)
        {
            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    await conn.OpenAsync();

                    var celestialObject = await conn.QueryFirstOrDefaultAsync<CelestialEntityModel>(
                        SqlLoader.GetSql(SqlResourceNames.CelestialObjects.CelestialObject_Get),
                        new { Id = id });

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
                _log.Error(ex, "Unable to load entity from database.");
                return new CelestialGetResult(ex);
            }
        }

        public async Task<CelestialSearchQueryResult> SearchCelestialObject(string searchText)
        {
            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    await conn.OpenAsync();

                    var searchResult = await conn.QueryAsync<CelestialSearchQueryResultModel>(
                        SqlLoader.GetSql(SqlResourceNames.CelestialObjects.CelestialObject_Search),
                        new { searchText = $"\"{searchText}*\"" });

                    if (!searchResult.Any())
                    {
                        return new CelestialSearchQueryResult(notFound: true);
                    }

                    return new CelestialSearchQueryResult(searchResult);
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex, "Unable to search for entity in database.");
                return new CelestialSearchQueryResult(ex);
                throw;
            }
        }

        // TODO: Currently returns an int, change to proper custom object
        public async Task<int> CreateCelestialObject(CelestialPostRequestModel request)
        {
            throw new NotImplementedException();
        }
    }
}
