using System;

namespace Astro.API.Application.Response.Delete
{
    public class CelestialDeleteResult
    {
        public CelestialDeleteResult()
        {
        }

        public CelestialDeleteResult(Exception ex)
        {
            Exception = ex;
        }

        public Exception Exception { get; protected set; }

        public bool HasException => Exception != null;
    }
}
