using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MinimalArchitecture.Api.Filters
{
    public class ApiExceptionFilter : IEndpointFilter
    {
        private readonly ILogger<ApiExceptionFilter> _logger;

        public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
        {
            _logger = logger;
        }

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            try
            {
                return await next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Exception handled in {ApiExceptionFilter}.", nameof(ApiExceptionFilter));

                return HandleException(exception);
            }
        }

        private static ProblemHttpResult HandleException(Exception exception)
        {
            var exceptionType = exception.GetType();

            switch (exceptionType)
            {
                default:
                    return HandleUnknownException();
            }
        }

        private static ProblemHttpResult HandleUnknownException()
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "An error occurred while processing your request.",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
            };

            return TypedResults.Problem(problemDetails);
        }
    }
}