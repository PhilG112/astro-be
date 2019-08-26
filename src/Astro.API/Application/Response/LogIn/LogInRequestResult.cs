using System;

namespace Astro.API.Application.Response.LogIn
{
    public class LogInRequestResult
    {
        public LogInRequestResult(LogInRequestResponseModel result)
        {
            Result = result;
        }

        public LogInRequestResult(bool notFound)
        {
            NotFound = notFound;
        }

        public LogInRequestResult(Exception ex)
        {
            Exception = ex;
        }

        public bool NotFound { get; protected set; }

        public Exception Exception { get; protected set; }

        public bool HasException => Exception != null;

        public LogInRequestResponseModel Result { get; protected set; }
    }
}
