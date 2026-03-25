using MediatR;
using Microsoft.AspNetCore.Mvc;
using Paybble.Api.Endpoints.Forms;
using Paybble.Application.Features.Categories.Commands.CreateCategory;

namespace Paybble.Api.Endpoints
{
    public class CategoriesEndpoint : IEndpoint
    {
        public void Map(WebApplication app)
        {
            var group = app.MapGroup("/categories").WithTags("Categories");

            group.Map("/", HandleCreateCategory)
                .WithName("CreateCategory")
                .Produces(StatusCodes.Status201Created)
                 .Produces(StatusCodes.Status400BadRequest)
                 .ProducesValidationProblem();
        }

        private static async Task<IResult> HandleCreateCategory(
            [FromForm] CreateCategoryForm form,
            [FromServices] IMediator mediator)
        {
            var command = new CreateCategoryCommand(form.Name);
            var result = await mediator.Send(command);
            return Results.Ok(result);
        }
    }
}
