using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Astro.API.ProblemDetailObjects
{
    public class BadRequestProblemDetails : ProblemDetails
    {
        public BadRequestProblemDetails(ValidationException ex)
        {
            var errors = ex.Errors.Any() ? ex.Errors.Select(e => e.ErrorMessage) : new List<string> { ex.Message };

            Status = StatusCodes.Status400BadRequest;
            Title = "Bad Request";
            Detail = string.Join("\n", errors);
            Instance = ex.Data["InstanceId"].ToString();
            Type = "https://httpstatuses.com/400";
        }
    }
}