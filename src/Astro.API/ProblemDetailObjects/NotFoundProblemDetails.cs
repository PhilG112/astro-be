using Astro.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Astro.API.ProblemDetailObjects
{
    public class NotFoundProblemDetails : ProblemDetails
    {
        public NotFoundProblemDetails(NotFoundException ex)
        {
            Status = StatusCodes.Status404NotFound;
            Title = "Not Found";
            Detail = ex.Message;
            Instance = ex.Data["InstanceId"].ToString();
            Type = "https://httpstatuses.com/404";
        }
    }
}