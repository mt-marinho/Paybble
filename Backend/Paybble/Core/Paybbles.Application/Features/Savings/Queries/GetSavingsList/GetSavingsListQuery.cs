using MediatR;

namespace Paybble.Application.Features.Savings.Queries.GetSavingsList
{
    public record GetSavingsListQuery() : IRequest<GetSavingsListResponse>;
}
