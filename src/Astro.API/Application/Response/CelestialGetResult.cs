using System;

namespace Astro.API.Application.Response
{
    public class CelestialGetResult
    {
        public CelestialGetResult(CelestialGetResponseModel result)
        {
            Result = result;
        }

        public CelestialGetResult(bool notFound)
        {
            NotFound = notFound;
        }

        public CelestialGetResult(Exception ex)
        {
            Exception = ex;
        }

        public bool NotFound { get; protected set; }

        public Exception Exception { get; protected set; }

        public bool HasException => Exception != null;

        public CelestialGetResponseModel Result { get; protected set; }
    }
}
