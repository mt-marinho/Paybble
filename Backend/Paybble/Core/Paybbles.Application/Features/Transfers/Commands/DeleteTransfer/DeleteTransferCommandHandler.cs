using MediatR;
using Paybble.Application.Contracts.Persistence;
using Paybble.Application.Exceptions;
using Paybble.Domain.Entities;

namespace Paybble.Application.Features.Transfers.Commands.DeleteTransfer
{
    public class DeleteTransferCommandHandler(ITransferRepository transferRepository) : IRequestHandler<DeleteTransferCommand>
    {
        public async Task Handle(DeleteTransferCommand request, CancellationToken cancellationToken)
        {
            var transfer = await transferRepository.GetByIdAsync(request.id);

            if (transfer == null)
                throw new NotFoundException(nameof(Transfer), request.id);

            await transferRepository.DeleteAsync(transfer);
        }
    }
}
