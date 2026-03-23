using MediatR;
using Paybble.Application.Contracts.Persistence;
using Paybble.Application.Exceptions;
using Paybble.Domain.Entities;

namespace Paybble.Application.Features.Transactions.Commands.PatchTransactionPaymentStatus
{
    public class PatchTransactionCommandHandler(ITransactionRepository transactionRepository) 
        : IRequestHandler<PatchTransactionCommand>
    {
        public async Task Handle(PatchTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await transactionRepository.GetByIdAsync(request.Id);
            
            if (transaction == null)
                throw new NotFoundException(nameof(Transaction), request.Id);

            if (request.Paid)
                transaction.MarkAsPaid();
            else
                transaction.MarkAsUnpaid();

            await transactionRepository.UpdateAsync(transaction);
        }
    }
}
