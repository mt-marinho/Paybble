using MediatR;
using Microsoft.AspNetCore.Mvc;
using Paybble.Application.Features.CreditCardPurchases.Commands.CreateCreditCardPurchase;
using Paybble.Application.Features.CreditCardPurchases.Commands.DeleteCreditCardPurchase;
using Paybble.Application.Features.CreditCardPurchases.Commands.UpdateCreditCardPurchase;
using Paybble.Application.Features.CreditCardPurchases.Queries.GetCreditCardPurchaseDetail;
using Paybble.Application.Features.CreditCardPurchases.Queries.GetCreditCardPurchaseList;

namespace Paybble.Api.Endpoints
{
    public class CreditCardPurchasesEndpoints : IEndpoint
    {
        public void Map(WebApplication app)
        {
            var group = app.MapGroup("/credit-card-purchases").WithTags("CreditCardPurchases");

            group.MapPost("/", HandleCreateCreditCardPurchases)
                .WithName("CreateCreditCardPurchases")
                .Produces(StatusCodes.Status201Created)
                .ProducesValidationProblem();

            group.MapDelete("/{id: int}", HandleDeleteCreditCardPurchase)
                .WithName("DeleteCreditCardPurchase")
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .ProducesValidationProblem();

            group.MapPut("/", HandleUpdateCreditCardPurchases)
                .WithName("UpdateCreditCardPurchase")
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound)
                .ProducesValidationProblem();

            group.MapGet("/{id: int}", HandleGetCreditCardPurchases)
                .WithName("GetCreditCardPurchase")
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .ProducesValidationProblem();

            group.MapGet("/", HandleGetCreditCardPurchasesList)
                .WithName("GetCreditCardPurchaseList")
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .ProducesValidationProblem();
        }

        public static async Task<IResult> HandleCreateCreditCardPurchases(
            [FromBody] CreateCreditCardPurchaseCommand command,
            [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(command);
            return Results.Ok(result);
        }

        public static async Task<IResult> HandleDeleteCreditCardPurchase(
            [FromRoute] int id,
            [FromServices] IMediator mediator)
        {
            var command = new DeleteCreditCardPurchaseCommand(id);
            await mediator.Send(command);
            return Results.NoContent();
        }

        public static async Task<IResult> HandleUpdateCreditCardPurchases(
            [FromBody] UpdateCreditCardPurchaseCommand command,
            [FromServices] IMediator mediator)
        {
            await mediator.Send(command);
            return Results.NoContent();
        }

        public static async Task<IResult> HandleGetCreditCardPurchases(
            [FromRoute] int id,
            [FromServices] IMediator mediator)
        {
            var query = new GetCreditCardPurchaseDetailQuery(id);
            var result = await mediator.Send(query);
            return Results.Ok(result);
        }

        public static async Task<IResult> HandleGetCreditCardPurchasesList(
            [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(new GetCreditCardPurchaseListQuery());
            return Results.Ok(result);
        }
    }
}
