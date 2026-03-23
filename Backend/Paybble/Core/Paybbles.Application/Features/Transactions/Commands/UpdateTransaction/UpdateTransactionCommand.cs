using MediatR;
using Paybble.Domain.Enums;

namespace Paybble.Application.Features.Transactions.Commands.UpdateTransaction
{
    public record UpdateTransactionCommand
    (
        int Id,
        string Description,
        decimal Value,
        int Year,
        int Month,
        Recurrence Recurrence,
        int Frequency,
        DateOnly Date,
        TransferType TransferType,
        TransactionType TransactionType
    ) : IRequest;
}
