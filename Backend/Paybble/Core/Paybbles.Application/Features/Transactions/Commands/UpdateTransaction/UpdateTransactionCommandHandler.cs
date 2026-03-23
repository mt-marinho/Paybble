using MediatR;
using Paybble.Application.Contracts.Persistence;
using Paybble.Application.Exceptions;
using Paybble.Domain.Entities;

namespace Paybble.Application.Features.Transactions.Commands.UpdateTransaction
{
    public class UpdateTransactionCommandHandler(ITransactionRepository transactionRepository) 
        : IRequestHandler<UpdateTransactionCommand>
    {
        public async Task Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await transactionRepository.GetByIdAsync(request.Id);

            if (transaction == null)
                throw new NotFoundException(nameof(Transaction), request.Id);

            transaction.ChangeDescription(request.Description);
            transaction.ChangeValue(request.Value);
            transaction.ChangeYear(request.Year);
            transaction.ChangeMonth(request.Month);
            transaction.ChangeRecurrence(request.Recurrence, request.Frequency);
            transaction.ChangeDate(request.Date);
            transaction.ChangeTransferType(request.TransferType);
            transaction.ChangetTransactionType(request.TransactionType);

            await transactionRepository.UpdateAsync(transaction);
        }
    }
}
