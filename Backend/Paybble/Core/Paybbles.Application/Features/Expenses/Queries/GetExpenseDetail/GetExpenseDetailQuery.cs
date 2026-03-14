using MediatR;

namespace Paybble.Application.Features.Expenses.Queries.GetExpenseDetail
{
    public record GetExpenseDetailQuery(int id) : IRequest<GetExpenseDetailResponse>;
}