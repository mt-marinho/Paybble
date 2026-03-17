using MediatR;

namespace Paybble.Application.Features.Savings.Queries.GetSavings
{
    public record GetSavingsQuery(int id) : IRequest<GetSavingsResponse>;
}
