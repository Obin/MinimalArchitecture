using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MinimalArchitecture.Api.Utilities
{
    public static class ResponseUtility
    {
        public static BadRequest<ProblemDetails> BadRequest(string error)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "An error occurred while processing your request.",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1\"",
                Detail = error
            };

            return TypedResults.BadRequest(problemDetails);
        }
    }
}