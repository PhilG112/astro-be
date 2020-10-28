using System.Collections.Generic;
using System.Threading.Tasks;

namespace Astro.Abstractions.Data
{
    public interface ISqlDataRepository
    {
        /// <summary>
        /// Query and map the first result to type <seealso cref="{T}"/>/>
        /// </summary>
        /// <typeparam name="T">Your type</typeparam>
        /// <param name="sql">SQL to be executed</param>
        /// <param name="sqlParams">SQL paramaters</param>
        /// <returns><seealso cref="{T}"/></returns>
        Task<T> QueryFirstAsync<T>(string sql, object sqlParams);

        /// <summary>
        /// Query and map first result. Returns null if no result.
        /// </summary>
        /// <param name="sql">SQL to be executed</param>
        /// <param name="sqlParams">SQL paramaters</param>
        /// <returns><seealso cref="{T}"/></returns>
        Task<T> QueryFirstOrDefaultAsync<T>(string sql, object sqlParams);

        /// <summary>
        /// Query and get a collection of results of type <seealso cref="{T}"/>
        /// </summary>
        /// <typeparam name="T">Your type</typeparam>
        /// <param name="sql">SQL to be executed</param>
        /// <param name="sqlParams">SQL paramaters</param>
        /// <returns><seealso cref="IEnumerable{T}"/></returns>
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object sqlParams);

        /// <summary>
        /// Execute an SQL script and return the number of rows affected.
        /// </summary>
        /// <param name="sql">SQL to be executed</param>
        /// <param name="sqlParams">SQL paramaters</param>
        /// <returns>The number of rows affected</returns>
        Task<int> ExecuteAsync(string sql, object sqlParams);
    }
}
