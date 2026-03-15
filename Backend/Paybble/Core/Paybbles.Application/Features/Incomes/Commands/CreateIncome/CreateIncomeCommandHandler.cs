using AutoMapper;
using MediatR;
using Paybble.Application.Contracts.Persistence;
using Paybble.Domain.Entities;

namespace Paybble.Application.Features.Incomes.Commands.CreateIncome
{
    public class CreateIncomeCommandHandler(IIncomeRepository incomeRepository, IMapper mapper) : IRequestHandler<CreateIncomeCommand, CreateIncomeReponse>
    {
        public async Task<CreateIncomeReponse> Handle(CreateIncomeCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateIncomeReponse();

            var income = new Income
            (
                request.Description,
                request.Value,
                request.Year,
                request.Month,
                request.Recurrence,
                request.Frequency,
                request.PaymentDate
            );

            var addedIncome = await incomeRepository.AddAsync(income);
            response.income = mapper.Map<CreateIncomeDTO>(addedIncome);
            return response;
        }
    }
}
