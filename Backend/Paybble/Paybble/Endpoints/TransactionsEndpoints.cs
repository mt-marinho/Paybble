using MediatR;
using Microsoft.AspNetCore.Mvc;
using Paybble.Application.Features.Transactions.Commands.CreateTransaction;
using Paybble.Application.Features.Transactions.Commands.DeleteTransaction;
using Paybble.Application.Features.Transactions.Commands.PatchTransactionPaymentStatus;
using Paybble.Application.Features.Transactions.Commands.UpdateTransaction;
using Paybble.Application.Features.Transactions.Queries.GetTransactionDetail;
using Paybble.Application.Features.Transactions.Queries.GetTransactionsByYearMonth;

namespace Paybble.Api.Endpoints
{
    public class TransactionsEndpoints : IEndpoint
    {
        public void Map(WebApplication app)
        {
            var group = app.MapGroup("/transactions").WithTags("Transactions");

            group.MapPost("/", HandleCreateTransaction)
                .WithName("CreateTransaction")
                .Produces(StatusCodes.Status201Created)
                .ProducesValidationProblem();

            group.MapPut("/{id:int}", HandleUpdateTransaction)
                .WithName("UpdateTransaction")
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound)
                .ProducesValidationProblem();

            group.MapPatch("/{id:int}/payment-status", HandlePatchTransactionPaymentStatus)
                .WithName("PatchTransactionPaymentStatus")
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound)
                .ProducesValidationProblem();

            group.MapDelete("/{id:int}", HandleDeleteTransaction)
                .WithName("DeleteTransaction")
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound)
                .ProducesValidationProblem();

            group.MapGet("/{id:int}", HandleGetTransactionDetail)
                .WithName("GetTransactionDetail")
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .ProducesValidationProblem();

            group.MapGet("/year/{year:int}", HandleGetTransactionsByYear)
                .WithName("GetTransactionsByYear")
                .Produces(StatusCodes.Status200OK)
                .ProducesValidationProblem();

            group.MapGet("/year/{year:int}/month/{month:int}", HandleGetTransactionsByYearMonth)
                .WithName("GetTransactionsByYearMonth")
                .Produces(StatusCodes.Status200OK)
                .ProducesValidationProblem();
        }

        private static async Task<IResult> HandleCreateTransaction(
            [FromBody] CreateTransactionCommand command,
            [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(command);
            return Results.Created($"/transactions/{result.Transaction.Id}", result);
        }

        private static async Task<IResult> HandleUpdateTransaction(
            [FromRoute] int id,
            [FromBody] UpdateTransactionCommand command,
            [FromServices] IMediator mediator)
        {
            if (id != command.Id)
            {
                return Results.BadRequest("Id in route does not match Id in body");
            }

            await mediator.Send(command);
            return Results.NoContent();
        }

        private static async Task<IResult> HandlePatchTransactionPaymentStatus(
            [FromRoute] int id,
            [FromBody] PatchTransactionPaymentStatusRequest request,
            [FromServices] IMediator mediator)
        {
            var command = new PatchTransactionCommand(id, request.Paid);
            await mediator.Send(command);
            return Results.NoContent();
        }

        private static async Task<IResult> HandleDeleteTransaction(
            [FromRoute] int id,
            [FromServices] IMediator mediator)
        {
            var command = new DeleteTransactionCommand(id);
            await mediator.Send(command);
            return Results.NoContent();
        }

        private static async Task<IResult> HandleGetTransactionDetail(
            [FromRoute] int id,
            [FromServices] IMediator mediator)
        {
            var query = new GetTransactionDetailQuery(id);
            var result = await mediator.Send(query);
            return Results.Ok(result);
        }

        private static async Task<IResult> HandleGetTransactionsByYear(
            [FromRoute] int year,
            [FromServices] IMediator mediator)
        {
            var query = new GetTransactionsByYearMonthQuery(year, null);
            var result = await mediator.Send(query);
            return Results.Ok(result);
        }

        private static async Task<IResult> HandleGetTransactionsByYearMonth(
            [FromRoute] int year,
            [FromRoute] int month,
            [FromServices] IMediator mediator)
        {
            var query = new GetTransactionsByYearMonthQuery(year, month);
            var result = await mediator.Send(query);
            return Results.Ok(result);
        }
    }

    public record PatchTransactionPaymentStatusRequest(bool Paid);
}
