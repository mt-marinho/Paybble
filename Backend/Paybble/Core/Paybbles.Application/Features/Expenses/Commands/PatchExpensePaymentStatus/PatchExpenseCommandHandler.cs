using MediatR;
using Paybble.Application.Contracts.Persistence;
using Paybble.Application.Exceptions;
using Paybble.Domain.Entities;

namespace Paybble.Application.Features.Expenses.Commands.PatchExpensePaymentStatus
{
    public class PatchExpenseCommandHandler(IExpensRepository expensRepository) : IRequestHandler<PatchExpenseCommand>
    {
        public async Task Handle(PatchExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = await expensRepository.GetByIdAsync(request.id);
            if(expense == null)
                throw new NotFoundException(nameof(Expense), request.id);

            expense.MarkAsPaid();

            await expensRepository.UpdateAsync(expense);
        }
    }
}
