using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimalArchitecture.Api.Filters;
using MinimalArchitecture.Api.Responses;
using MinimalArchitecture.Api.Utilities;
using MinimalArchitecture.Application.Account.Commands.CreateAccount;
using MinimalArchitecture.Application.Account.Queries.GetAccountDetails;
using System.Threading.Tasks;

namespace MinimalArchitecture.Api.Routings
{
    public static class AccountRouting
    {
        public static void Register(WebApplication webApplication)
        {
            var routeGroup = webApplication
                .MapGroup("/account")
                .AddEndpointFilter<ApiExceptionFilter>();

            routeGroup.MapGet("/get-account-details", async ([AsParameters] GetAccountDetailsQuery query, [FromServices] IMediator mediator) =>
            {
                var result = await mediator.Send(query);

                if (result.IsError)
                {
                    return Results.BadRequest();
                }

                return Results.Ok(result.Value);
            });

            routeGroup.MapPost("/create-account", async Task<Results<Ok<CreateResponse>, BadRequest<ProblemDetails>>> ([FromBody] CreateAccountCommand command, [FromServices] IMediator mediator) =>
            {
                var result = await mediator.Send(command);

                if (result.IsError)
                {
                    return ResponseUtility.BadRequest(result.Error);
                }

                return TypedResults.Ok(new CreateResponse(result.Value));
            });
        }
    }
}