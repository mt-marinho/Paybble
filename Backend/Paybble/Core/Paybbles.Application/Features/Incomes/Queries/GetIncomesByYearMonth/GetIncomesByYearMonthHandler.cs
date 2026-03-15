using AutoMapper;
using MediatR;
using Paybble.Application.Contracts.Persistence;
using Paybble.Application.Exceptions;
using Paybble.Domain.Entities;

namespace Paybble.Application.Features.Incomes.Queries.GetIncomesByYearMonth
{
    public class GetIncomesByYearMonthHandler(IIncomeRepository incomeRepository, IMapper mapper) : IRequestHandler<GetIncomesByYearMonthQuery, GetIncomesByYearMonthResponse>
    {
        public async Task<GetIncomesByYearMonthResponse> Handle(GetIncomesByYearMonthQuery request, CancellationToken cancellationToken)
        {
            var response = new GetIncomesByYearMonthResponse();

            var incomes = await incomeRepository.GetIncomesByYearMonthAsync(request.year, request.month);

            if(incomes == null)
                throw new NotFoundException(nameof(Income), request.id);

            response.incomes = mapper.Map<List<IncomesByYearMonthVm>>(incomes);
            return response;
        }
    }
}
