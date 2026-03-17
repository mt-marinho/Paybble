using AutoMapper;
using MediatR;
using Paybble.Application.Contracts.Persistence;
using Paybble.Application.Exceptions;
using Paybble.Domain.Entities;

namespace Paybble.Application.Features.Transfers.Queries.GetTransfer
{
    public class GetTransferQueryHandler(ITransferRepository transferRepository, IMapper mapper) : IRequestHandler<GetTransferQuery, GetTransferResponse>
    {
        public async Task<GetTransferResponse> Handle(GetTransferQuery request, CancellationToken cancellationToken)
        {
            var response = new GetTransferResponse();

            var transfer = await transferRepository.GetByIdAsync(request.id);

            if (transfer == null)
                throw new NotFoundException(nameof(Transfer), request.id);

            response.trnasfer = mapper.Map<GetTransferDTO>(transfer);
            return response;
        }
    }
}
