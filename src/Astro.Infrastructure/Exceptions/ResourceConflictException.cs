using System;
using System.Runtime.Serialization;

namespace Astro.Infrastructure.Exceptions
{
    /// <summary>
    /// This exception is used when a user tries to upload a resource that already exists.
    /// </summary>
    public class ResourceConflictException : Exception
    {
        public ResourceConflictException()
        {
        }

        public ResourceConflictException(string message) : base(message)
        {
        }

        public ResourceConflictException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ResourceConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
