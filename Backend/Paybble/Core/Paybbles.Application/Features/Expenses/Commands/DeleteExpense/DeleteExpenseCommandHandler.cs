using MediatR;
using Paybble.Application.Contracts.Persistence;
using Paybble.Application.Exceptions;
using Paybble.Domain.Entities;

namespace Paybble.Application.Features.Expenses.Commands.DeleteExpense
{
    public class DeleteExpenseCommandHandler(IExpensRepository expensRepository) : IRequestHandler<DeleteExpenseCommand>
    {
        public async Task Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = await expensRepository.GetByIdAsync(request.id);
            if (expense == null)
                throw new NotFoundException(nameof(Expense), request.id);

            await expensRepository.DeleteAsync(expense);
        }
    }
}
