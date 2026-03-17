using AutoMapper;
using MediatR;
using Paybble.Application.Contracts.Persistence;
using Paybble.Domain.Entities;

namespace Paybble.Application.Features.Transfers.Commands.CreateTransfer
{
    public class CreateTransferCommandHandler(ITransferRepository transferRepository, IMapper mapper) : IRequestHandler<CreateTransferCommand, CreateTransferResponse>
    {
        public async Task<CreateTransferResponse> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateTransferResponse();

            var transfer = new Transfer(
                request.description,
                request.value,
                request.year,   
                request.month,
                request.type
            );

            transfer = await transferRepository.AddAsync(transfer);

            response.transfer = mapper.Map<CreateTransferDTO>(transfer);

            return response;
        }
    }
}
