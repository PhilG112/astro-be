using System;

namespace Astro.API.Application.Response.Post
{
    public class CelestialPostResult
    {
        public CelestialPostResult(int result)
        {
            Result = result;
        }

        public CelestialPostResult(Exception ex)
        {
            Exception = ex;
        }

        public Exception Exception { get; protected set; }

        public bool HasException => Exception != null;

        public int Result { get; protected set; }
    }
}
