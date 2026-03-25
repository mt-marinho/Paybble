using MediatR;

namespace Paybble.Application.Features.Categories.Commands.CreateCategory
{
    public record CreateCategoryCommand
    (
        string Name
    ) : IRequest<CreateCategoryResponse>;
}
