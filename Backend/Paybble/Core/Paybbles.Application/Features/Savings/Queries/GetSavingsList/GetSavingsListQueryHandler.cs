using AutoMapper;
using MediatR;
using Paybble.Application.Contracts.Persistence;
using Paybble.Application.Exceptions;
using Paybble.Domain.Entities;

namespace Paybble.Application.Features.Savings.Queries.GetSavingsList
{
    public class GetSavingsListQueryHandler(ISavingsRepository savingsRepository, IMapper mapper) : IRequestHandler<GetSavingsListQuery, GetSavingsListResponse>
    {
        public async Task<GetSavingsListResponse> Handle(GetSavingsListQuery request, CancellationToken cancellationToken)
        {
            var response = new GetSavingsListResponse();

            var savingsList = await savingsRepository.ListAllAsync();

            if(savingsList == null)
                throw new NotFoundException(nameof(Income), request);

            response.savings = mapper.Map<List<GetSavingsListDTO>>(savingsList);
            return response;
        }
    }
}
