using AutoMapper;
using MediatR;
using Paybble.Application.Contracts.Persistence;
using Paybble.Application.Exceptions;
using Paybble.Domain.Entities;

namespace Paybble.Application.Features.Savings.Queries.GetSavings
{
    public class GetSavingsQueryHandler(ISavingsRepository savingsRepository, IMapper mapper) : IRequestHandler<GetSavingsQuery, GetSavingsResponse>
    {
        public async Task<GetSavingsResponse> Handle(GetSavingsQuery request, CancellationToken cancellationToken)
        {
            var response = new GetSavingsResponse();
            var savings = await savingsRepository.GetByIdAsync(request.id);

            if(savings == null)
                throw new NotFoundException(nameof(Saving), request.id);

            response.savings = mapper.Map<GetSavingsDTO>(savings);
            return response;
        }
    }
}
