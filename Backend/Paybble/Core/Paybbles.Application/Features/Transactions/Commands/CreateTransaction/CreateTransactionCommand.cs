using MediatR;
using Paybble.Domain.Enums;

namespace Paybble.Application.Features.Transactions.Commands.CreateTransaction
{
    public record CreateTransactionCommand
    (
        string Description,
        decimal Value,
        int Year,
        int Month,
        Recurrence Recurrence,
        int Frequency,
        DateOnly Date,
        TransferType TransferType,
        TransactionType TransactionType
    ) : IRequest<CreateTransactionResponse>;
}
