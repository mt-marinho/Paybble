using MediatR;
using Paybble.Application.Contracts.Persistence;
using Paybble.Application.Exceptions;
using Paybble.Domain.Entities;

namespace Paybble.Application.Features.Incomes.Commands.DeleteIncome
{
    public class DeleteIncomeCommandHandler(IIncomeRepository incomeRepository) : IRequestHandler<DeleteIncomeCommand>
    {
        public async Task Handle(DeleteIncomeCommand request, CancellationToken cancellationToken)
        {
            var income = await incomeRepository.GetByIdAsync(request.id);

            if (income == null)
                throw new NotFoundException(nameof(Income), request.id);

            await incomeRepository.DeleteAsync(income);
        }
    }
}
