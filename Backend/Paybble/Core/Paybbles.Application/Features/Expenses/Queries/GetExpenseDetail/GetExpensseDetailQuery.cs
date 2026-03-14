using MediatR;

namespace Paybble.Application.Features.Expenses.Queries.GetExpense
{
    public record GetExpensseDetailQuery(int id) : IRequest<ExpenseDetailVm>;
}
