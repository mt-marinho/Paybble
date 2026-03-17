using MediatR;
using Paybble.Application.Contracts.Persistence;
using Paybble.Application.Exceptions;
using Paybble.Domain.Entities;

namespace Paybble.Application.Features.Transfers.Commands.UpdateTransfer
{
    public class UpdateTransferCommandHandler(ITransferRepository transferRepository) : IRequestHandler<UpdateTransferCommand>
    {
        public async Task Handle(UpdateTransferCommand request, CancellationToken cancellationToken)
        {
            var transfer = await transferRepository.GetByIdAsync(request.id);

            if (transfer == null)
                throw new NotFoundException(nameof(Transfer), request.id);

            transfer.ChangeDescription(request.description);
            transfer.ChangeValue(request.value);
            transfer.ChangeYear(request.year);
            transfer.ChangeMonth(request.month);
            transfer.ChangetType(request.Type);

            await transferRepository.UpdateAsync(transfer);
        }
    }
}
