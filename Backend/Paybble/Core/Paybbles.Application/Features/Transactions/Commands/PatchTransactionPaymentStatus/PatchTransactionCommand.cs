using MediatR;

namespace Paybble.Application.Features.Transactions.Commands.PatchTransactionPaymentStatus
{
    public record PatchTransactionCommand(int Id, bool Paid) : IRequest;
}
