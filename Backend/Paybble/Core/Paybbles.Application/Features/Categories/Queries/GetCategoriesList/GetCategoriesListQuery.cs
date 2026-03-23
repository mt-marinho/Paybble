using MediatR;

namespace Paybble.Application.Features.Categories.Queries.GetCategoriesList
{
    public record GetCategoriesListQuery() : IRequest<GetCategoriesListResponse>;
}
