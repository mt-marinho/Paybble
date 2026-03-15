using MediatR;
using Paybble.Application.Contracts.Persistence;
using Paybble.Application.Exceptions;
using Paybble.Domain.Entities;

namespace Paybble.Application.Features.Expenses.Commands.UpdateExpense
{
    public class UpdateExpenseCommandHandler(IExpensRepository expensRepository) : IRequestHandler<UpdateExpenseCommand>
    {
        public async Task Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = await expensRepository.GetByIdAsync(request.id);

            if (expense is null)
                throw new NotFoundException(nameof(Expense), request.id);

            expense.ChangeDescription(request.description);
            expense.ChangeValue(request.value);
            expense.ChangeDueDate(request.DueDate);
            expense.ChangeRecurrence(request.recurrence, request.frequency);

            await expensRepository.UpdateAsync(expense);
        }
    }
}
