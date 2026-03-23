using MediatR;
using Paybble.Application.Contracts.Persistence;
using Paybble.Application.Exceptions;
using Paybble.Domain.Entities;

namespace Paybble.Application.Features.Transactions.Commands.DeleteTransaction
{
    public class DeleteTransactionCommandHandler(ITransactionRepository transactionRepository) 
        : IRequestHandler<DeleteTransactionCommand>
    {
        public async Task Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await transactionRepository.GetByIdAsync(request.Id);

            if (transaction == null)
                throw new NotFoundException(nameof(Transaction), request.Id);

            await transactionRepository.DeleteAsync(transaction);
        }
    }
}
