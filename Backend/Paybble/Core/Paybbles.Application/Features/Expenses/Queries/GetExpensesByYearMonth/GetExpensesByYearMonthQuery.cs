using MediatR;

namespace Paybble.Application.Features.Expenses.Queries.GetExpensesByYearMonth
{
    public record GetExpensesByYearMonthQuery(int year, int? month) : IRequest<ExpensesByYearMonthResponse>;
}
