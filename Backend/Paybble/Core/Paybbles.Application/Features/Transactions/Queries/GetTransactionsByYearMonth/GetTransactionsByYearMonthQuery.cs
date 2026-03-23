using MediatR;

namespace Paybble.Application.Features.Transactions.Queries.GetTransactionsByYearMonth
{
    public record GetTransactionsByYearMonthQuery
    (
        int Year,
        int? Month
    ) : IRequest<TransactionsByYearMonthResponse>;
}
