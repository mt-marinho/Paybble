using MediatR;
using Paybble.Application.Contracts.Persistence;
using Paybble.Application.Exceptions;
using Paybble.Domain.Entities;

namespace Paybble.Application.Features.Savings.Commands.UpdateSavings
{
    public class UpdateSavingsCommandHandler(ISavingsRepository savingsRepository) : IRequestHandler<UpdateSavingsCommand>
    { 
        public async Task Handle(UpdateSavingsCommand request, CancellationToken cancellationToken)
        {
            var savings = await savingsRepository.GetByIdAsync(request.id);

            if (savings == null)
                throw new NotFoundException(nameof(Saving), request.id);

            savings.ChangeDescription(request.description);
            savings.ChangeGoalValue(request.goalValue);

            await savingsRepository.UpdateAsync(savings);
        }
    }
}
