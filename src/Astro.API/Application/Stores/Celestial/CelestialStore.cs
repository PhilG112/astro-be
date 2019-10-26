using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Astro.API.Application.Extensions;
using Astro.API.Application.Request.Post;
using Astro.API.Application.Request.Update;
using Astro.API.Application.Response.Post;
using Astro.API.Application.Response.Delete;
using Astro.API.Application.Response.Get;
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

        public async Task<CelestialSearchQueryResult> SearchCelestialObjectAsync(string searchText)
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
            }
        }

        public async Task<CelestialPostResult> CreateCelestialObjectAsync(CelestialPostRequestModel request)
        {
            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    await conn.OpenAsync();

                    var cParams = new
                    {
                        ObjectType = request.ObjectType.ToString(),
                        request.Magnitude,
                        request.AbsoluteMagnitude,
                        request.Name,
                        request.Designation1,
                        request.Designation2,
                        request.Designation3,
                        request.Designation4,
                        request.Description
                    };

                    var createResultId = await conn.QuerySingleAsync<int>(
                        SqlLoader.GetSql(SqlResourceNames.CelestialObjects.CelestialObject_Create),
                        cParams);

                    foreach (var distance in request.Distances)
                    {
                        var dParams = new
                        {
                            CelestialObjectId = createResultId,
                            DistanceType = distance.DistanceType.ToString(),
                            distance.Tolerance,
                            distance.Value
                        };

                        await conn.ExecuteAsync(
                            SqlLoader.GetSql(SqlResourceNames.Distances.Distances_Create),
                            dParams);
                    }

                    return new CelestialPostResult(createResultId);
                }
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
                using (var conn = new SqlConnection(_connString))
                {
                    var cParams = new
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
                        request.Description
                    };

                    await conn.ExecuteAsync(
                        SqlLoader.GetSql(SqlResourceNames.CelestialObjects.CelestialObject_Update),
                        cParams);

                    foreach (var distance in request.Distances)
                    {
                        var dParams = new
                        {
                            CelestialObjectId = request.Id,
                            DistanceType = distance.DistanceType.ToString(),
                            distance.Value,
                            distance.Tolerance
                        };

                        await conn.ExecuteAsync(
                            SqlLoader.GetSql(SqlResourceNames.Distances.Distances_Update),
                            dParams);
                    }

                    return new CelestialUpdateResult();
                }
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
