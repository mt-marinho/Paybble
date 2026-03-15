using MediatR;
using Paybble.Application.Contracts.Persistence;
using Paybble.Application.Exceptions;
using Paybble.Domain.Entities;

namespace Paybble.Application.Features.Incomes.Commands.UpdateIncome
{
    public class UpdateIncomeCommandHandler(IIncomeRepository incomeRepository) : IRequestHandler<UpdateIncomeCommand>
    {
        public async Task Handle(UpdateIncomeCommand request, CancellationToken cancellationToken)
        {
            var income = await incomeRepository.GetByIdAsync(request.id);

            if (income == null)
                throw new NotFoundException(nameof(Income), request.id);

            income.ChangeDescription(request.description);
            income.ChangeValue(request.value);
            income.ChangeRecurrence(request.recurrence, request.frequency);
            income.ChangePaymentDate(request.PaymentDate);

            await incomeRepository.UpdateAsync(income);
        }
    }
}
