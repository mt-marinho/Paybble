using MediatR;

namespace Paybble.Application.Features.Categories.Commands.CreateCategory
{
    public record CreateCategoryCommand
    (
        string Name,
        string? Description,
        string? Icon,
        string? Color
    ) : IRequest<CreateCategoryResponse>;
}
