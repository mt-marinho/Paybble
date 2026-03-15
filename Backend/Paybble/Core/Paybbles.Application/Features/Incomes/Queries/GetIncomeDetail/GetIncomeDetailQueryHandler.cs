using AutoMapper;
using MediatR;
using Paybble.Application.Contracts.Persistence;
using Paybble.Application.Exceptions;
using Paybble.Application.Features.Incomes.Queries.GetIncome;
using Paybble.Domain.Entities;

namespace Paybble.Application.Features.Incomes.Queries.GetIncomeDetail
{
    public class GetIncomeDetailQueryHandler(IIncomeRepository incomeRepository, IMapper mapper) : IRequestHandler<GetincomeDetailQuery, GetIncomeDetailResponse>
    {
        public async Task<GetIncomeDetailResponse> Handle(GetincomeDetailQuery request, CancellationToken cancellationToken)
        {
            var response = new GetIncomeDetailResponse();

            var income = await incomeRepository.GetByIdAsync(request.id);

            if (income == null)
                throw new NotFoundException(nameof(Income), request.id);

            response.income = mapper.Map<IncomeDetailVm>(income);
            return response;
        }
    }
}
