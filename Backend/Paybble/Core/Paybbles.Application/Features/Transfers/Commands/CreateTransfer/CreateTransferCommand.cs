using MediatR;
using Paybble.Domain.Enums;

namespace Paybble.Application.Features.Transfers.Commands.CreateTransfer
{
    public record CreateTransferCommand(
        string description, 
        decimal value, 
        int year, 
        int month, 
        TransferType type
    ) : IRequest<CreateTransferResponse>;
}
