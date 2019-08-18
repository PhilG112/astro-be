using System;

namespace Astro.API.Application.Response.Create
{
    public class CelestialCreateResult
    {
        public CelestialCreateResult(int result)
        {
            Result = result;
        }

        public CelestialCreateResult(Exception ex)
        {
            Exception = ex;
        }

        public Exception Exception { get; protected set; }

        public bool HasException => Exception != null;

        public int Result { get; protected set; }
    }
}
