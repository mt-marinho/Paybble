using MediatR;

namespace Paybble.Application.Features.Transactions.Queries.GetTransactionDetail
{
    public record GetTransactionDetailQuery(int Id) : IRequest<GetTransactionDetailResponse>;
}
