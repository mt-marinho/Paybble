using MediatR;

namespace Paybble.Application.Features.Expenses.Commands.DeleteExpense
{
    public record DeleteExpenseCommand(int id) : IRequest; 
}
