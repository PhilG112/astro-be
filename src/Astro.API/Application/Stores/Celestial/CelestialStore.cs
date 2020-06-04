using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Astro.API.Application.Extensions;
using Astro.API.Application.Request.Post;
using Astro.API.Application.Request.Update;
using Astro.API.Application.Response.Delete;
using Astro.API.Application.Response.Get;
using Astro.API.Application.Response.Post;
using Astro.API.Application.Response.Search;
using Astro.API.Application.Response.Update;
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

        public async Task<CelestialGetResult> GetCelestialObjectAsync(int id)
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

                    return new CelestialGetResult(celestialObject.ToResponseModel());
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex, "Unable to load entity from database.");
                return new CelestialGetResult(ex);
            }
        }

        public async Task<CelestialSearchQueryResult> SearchCelestialObjectAsync(string searchText)
        {
            try
            {
                using var conn = new SqlConnection(_connString);
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
            catch (Exception ex)
            {
                _log.Error(ex, "Unable to search for entity in database.");
                return new CelestialSearchQueryResult(ex);
            }
        }

        public async Task<CelestialPostResult> CreateCelestialObjectAsync(CelestialPostRequestModel request)
        {
            try
            {
                using var conn = new SqlConnection(_connString);
                await conn.OpenAsync();

                var sqlParams = new
                {
                    ObjectType = request.ObjectType.ToString(),
                    request.Magnitude,
                    request.AbsoluteMagnitude,
                    request.Name,
                    request.Designation1,
                    request.Designation2,
                    request.Designation3,
                    request.Designation4,
                    request.Description,
                    request.Distance,
                    request.DistanceTolerance
                };

                var createResultId = await conn.QuerySingleAsync<int>(
                    SqlLoader.GetSql(SqlResourceNames.CelestialObjects.CelestialObject_Create),
                    sqlParams);

                return new CelestialPostResult(createResultId);
            }
            catch (Exception ex)
            {
                _log.Error(ex, "Unable to create object.");
                return new CelestialPostResult(ex);
            }
        }

        public async Task<CelestialUpdateResult> UpdateCelestialObjectAsync(CelestialUpdateRequestModel request)
        {
            try
            {
                using var conn = new SqlConnection(_connString);
                var sqlParams = new
                {
                    request.Id,
                    request.Magnitude,
                    request.AbsoluteMagnitude,
                    request.Name,
                    ObjectType = request.ObjectType.ToString(),
                    request.Designation1,
                    request.Designation2,
                    request.Designation3,
                    request.Designation4,
                    request.Description,
                    request.Distance,
                    request.DistanceTolerance
                };

                await conn.ExecuteAsync(
                    SqlLoader.GetSql(SqlResourceNames.CelestialObjects.CelestialObject_Update),
                    sqlParams);

                return new CelestialUpdateResult();
            }
            catch (Exception ex)
            {
                _log.Error(ex, $"Unable to update object with id: {request.Id}");
                return new CelestialUpdateResult(ex);
            }
        }

        public async Task<CelestialDeleteResult> DeleteCelestialObjectAsync(int id)
        {
            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    await conn.OpenAsync();

                    await conn.ExecuteAsync(
                        SqlLoader.GetSql(SqlResourceNames.CelestialObjects.CelestialObject_Delete),
                        new { Id = id });

                    return new CelestialDeleteResult();
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex, $"Unable to delete object with id: {id}");
                return new CelestialDeleteResult(ex);
            }
        }
    }
}
