using MediatR;

namespace Paybble.Application.Features.Transactions.Commands.DeleteTransaction
{
    public record DeleteTransactionCommand(int Id) : IRequest;
}
