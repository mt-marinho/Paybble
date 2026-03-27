using MediatR;
using Microsoft.AspNetCore.Mvc;
using Paybble.Application.Features.Savings.Commands.CreateSavings;
using Paybble.Application.Features.Savings.Commands.DeleteSavings;
using Paybble.Application.Features.Savings.Commands.UpdateSavings;
using Paybble.Application.Features.Savings.Queries.GetSavings;
using Paybble.Application.Features.Savings.Queries.GetSavingsList;
using System.Security.Cryptography.X509Certificates;

namespace Paybble.Api.Endpoints
{
    public class SavingsEndipoints : IEndpoint
    {
        public void Map(WebApplication app)
        {
            var group = app.MapGroup("/Savings").WithTags("Savings");

            group.MapPost("/", HandleCreateSavings)
                .WithName("CreateSavings")
                .Produces(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest)
                .ProducesValidationProblem();

            group.MapDelete("/{id : int}", HandleDeleteSavings)
                .WithName("DeleteSavings")
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound)
                .ProducesValidationProblem();

            group.MapPut("/", HandleUpdateSavings)
                .WithName("UpdateSavings")
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound)
                .ProducesValidationProblem();

            group.MapGet("/{id : int}", HandleGetSavingsDetail)
                .WithName("GetSavingsDetail")
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .ProducesValidationProblem();

            group.MapGet("/", HandleGetSavingsList)
                .WithName("GetSavingsList")
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .ProducesValidationProblem();
        }

        public async static Task<IResult> HandleCreateSavings(
            [FromBody] CreateSavingsCommand command,
            [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(command);
            return Results.Ok(result);
        }

        public async static Task<IResult> HandleDeleteSavings(
            [FromRoute] DeleteSavingsCommand id,
            [FromServices] IMediator mediator)
        {
            await mediator.Send(id);
            return Results.NoContent();
        }

        public async static Task<IResult> HandleUpdateSavings(
            [FromBody] UpdateSavingsCommand command,
            [FromServices] IMediator mediator)
        {
            await mediator.Send(command);
            return Results.NoContent();
        }

        public async static Task<IResult> HandleGetSavingsDetail(
            [FromRoute] GetSavingsQuery query,
            [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(query);
            return Results.Ok(result);
        }

        public async static Task<IResult> HandleGetSavingsList(
            [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(new GetSavingsListQuery());
            return Results.Ok(result);
        }
    }
}
