using System;
using System.Collections.Generic;

namespace Astro.API.Application.Response.Search
{
    public class CelestialSearchQueryResult
    {
        public CelestialSearchQueryResult(IEnumerable<CelestialSearchQueryResultModel> results)
        {
            Results = results;
        }

        public CelestialSearchQueryResult(bool notFound)
        {
            NotFound = notFound;
        }

        public CelestialSearchQueryResult(Exception ex)
        {
            Exception = ex;
        }

        public bool NotFound { get; protected set; }

        public Exception Exception { get; protected set; }

        public bool HasException => Exception != null;

        public IEnumerable<CelestialSearchQueryResultModel> Results { get; protected set; }
    }
}
