using Astro.Abstractions.Data;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Astro.Domain.Data
{
    public class DapperDataRepository : ISqlDataRepository
    {
        private readonly ISqlConnectionFactory _sqlConnFactory;

        public DapperDataRepository(ISqlConnectionFactory sqlConnFactory)
        {
            _sqlConnFactory = sqlConnFactory;
        }

        public async Task<int> ExecuteAsync(string sql, object sqlParams)
        {
            using var conn = GetOpenSqlConnection();

            return await conn.ExecuteAsync(sql, sqlParams);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object sqlParams)
        {
            using var conn = GetOpenSqlConnection();

            return await conn.QueryAsync<T>(sql, sqlParams);
        }

        public async Task<T> QueryFirstAsync<T>(string sql, object sqlParams)
        {
            using var conn = GetOpenSqlConnection();

            return await conn.QueryFirstAsync<T>(sql, sqlParams);
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object sqlParams)
        {
            using var conn = GetOpenSqlConnection();

            return await conn.QueryFirstOrDefaultAsync<T>(sql, sqlParams);
        }

        private IDbConnection GetOpenSqlConnection() => _sqlConnFactory.CreateOpenConnection();
    }
}
