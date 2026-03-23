using MediatR;

namespace Paybble.Application.Features.Categories.Queries.GetCategoryDetail
{
    public record GetCategoryDetailQuery(int Id) : IRequest<GetCategoryDetailResponse>;
}
