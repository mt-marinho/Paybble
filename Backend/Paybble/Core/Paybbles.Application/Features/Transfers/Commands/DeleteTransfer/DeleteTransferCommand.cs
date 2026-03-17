using MediatR;

namespace Paybble.Application.Features.Transfers.Commands.DeleteTransfer
{
    public record DeleteTransferCommand(int id) : IRequest;
}
