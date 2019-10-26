using System;

namespace Astro.API.Application.Response.Post
{
    public class UploadPostResult
    {
        public UploadPostResult()
        {
        }

        public UploadPostResult(Exception ex)
        {
            Exception = ex;
        }

        public Exception Exception { get; protected set; }

        public bool HasException => Exception != null;
    }
}
