using Astro.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Astro.API.ProblemDetailObjects
{
    public class ResourceConflictProblemDetails : ProblemDetails
    {
        public ResourceConflictProblemDetails(ResourceConflictException ex)
        {
            Status = StatusCodes.Status409Conflict;
            Title = "Conflict";
            Detail = ex.Message;
            Instance = ex.Data["InstanceId"].ToString();
            Type = "https://httpstatuses.com/409";
        }
    }
}
