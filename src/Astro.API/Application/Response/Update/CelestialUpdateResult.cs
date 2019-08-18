using System;

namespace Astro.API.Application.Response.Update
{
    public class CelestialUpdateResult
    {
        public CelestialUpdateResult()
        {
        }

        public CelestialUpdateResult(Exception ex)
        {
            Exception = ex;
        }

        public Exception Exception { get; protected set; }

        public bool HasException => Exception != null;
    }
}
