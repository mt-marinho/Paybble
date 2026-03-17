using MediatR;
using Paybble.Domain.Enums;

namespace Paybble.Application.Features.Transfers.Commands.UpdateTransfer
{
    public record UpdateTransferCommand(int id, string description, decimal value, int year, int month, TransferType Type) : IRequest;
}
