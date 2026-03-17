using MediatR;
using Paybble.Application.Contracts.Persistence;
using Paybble.Application.Exceptions;
using Paybble.Domain.Entities;

namespace Paybble.Application.Features.Savings.Commands.DeleteSavings
{
    public class DeleteSavingsHandler(ISavingsRepository savingsRepository) : IRequestHandler<DeleteSavingsCommand>
    {
        public async Task Handle(DeleteSavingsCommand request, CancellationToken cancellationToken)
        {
            var savings = await savingsRepository.GetByIdAsync(request.id);

            if (savings == null)
                throw new NotFoundException(nameof(Income), request.id);
            
            await savingsRepository.DeleteAsync(savings);
        }
    }
}
