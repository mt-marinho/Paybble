using MediatR;
using Microsoft.AspNetCore.Mvc;
using Paybble.Application.Features.Categories.Commands.CreateCategory;
using Paybble.Application.Features.Categories.Commands.DeleteCategory;
using Paybble.Application.Features.Categories.Queries.GetCategoriesList;
using Paybble.Application.Features.Categories.Queries.GetCategoryDetail;

namespace Paybble.Api.Endpoints
{
    public class CategoriesEndpoint : IEndpoint
    {
        public void Map(WebApplication app)
        {
            var group = app.MapGroup("/categories").WithTags("Categories");

            group.Map("/{name: string}", HandleCreateCategory)
                .WithName("CreateCategory")
                .Produces(StatusCodes.Status201Created)
                .ProducesValidationProblem();

            group.MapDelete("/{id: int}", HandleDeleteCategory)
                .WithName("DeleteCategory")
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound)
                .ProducesValidationProblem(); 

            group.MapGet("/{id: int}", HandleGetCategory)
                .WithName("GetCategory")
                .ProducesProblem(StatusCodes.Status204NoContent)
                .ProducesProblem(StatusCodes.Status404NotFound)
                .ProducesValidationProblem();

            group.MapGet("/", HandleGetCategoriesList)
                .WithName("GetCategoriesList")
                .ProducesProblem(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status404NotFound)
                .ProducesValidationProblem();
        }

        private static async Task<IResult> HandleCreateCategory(
            [FromBody] CreateCategoryCommand command,
            [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(command);
            return Results.Ok(result);
        }

        public static async Task<IResult> HandleDeleteCategory(
            [FromRoute] int id,
            [FromServices] IMediator mediator)
        {
            var command = new DeleteCategoryCommand(id);
            await mediator.Send(command);
            return Results.NoContent();
        }

        public static async Task<IResult> HandleGetCategory(
            [FromRoute] int id,
            [FromServices] IMediator mediator)
        {
            var query = new GetCategoryDetailQuery(id);
            var result = await mediator.Send(query);
            return Results.Ok(result);
        }

        public static async Task<IResult> HandleGetCategoriesList(
            [FromServices] IMediator mediator)
        {
            var result = mediator.Send(new GetCategoriesListQuery());
            return Results.Ok(result);
        }
    }
}
