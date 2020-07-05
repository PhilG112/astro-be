using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Astro.API.ProblemDetailObjects
{
    public class ServerErrorProblemDetails : ProblemDetails
    {
        public ServerErrorProblemDetails(Exception ex)
        {
            Status = StatusCodes.Status500InternalServerError;
            Title = "Internal Server Error";
            Detail = ex.Message;
            Instance = ex.Data["InstanceId"].ToString();
            Type = "https://httpstatuses.com/500";
        }
    }
}