using MediatR;

namespace Paybble.Application.Features.Categories.Commands.UpdateCategory
{
    public record UpdateCategoryCommand
    (
        int Id,
        string Name,
        string? Description,
        string? Icon,
        string? Color
    ) : IRequest;
}
