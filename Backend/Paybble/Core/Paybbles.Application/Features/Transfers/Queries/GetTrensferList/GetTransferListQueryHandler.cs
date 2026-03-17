using AutoMapper;
using MediatR;
using Paybble.Application.Contracts.Persistence;
using Paybble.Application.Exceptions;
using Paybble.Domain.Entities;

namespace Paybble.Application.Features.Transfers.Queries.GetTrensferList
{
    public class GetTransferListQueryHandler(ITransferRepository transferRepository, IMapper mapper) : IRequestHandler<GetTransferListQuery, GetTransferListResponse>
    {
        public async Task<GetTransferListResponse> Handle(GetTransferListQuery request, CancellationToken cancellationToken)
        {
            var response = new GetTransferListResponse();

            var transfers = await transferRepository.ListAllAsync();

            if(transfers == null)
                throw new NotFoundException(nameof(Transfer), "");

            response.transfers = mapper.Map<List<GetTransferListDTO>>(transfers);
            return response;
        }
    }
}
