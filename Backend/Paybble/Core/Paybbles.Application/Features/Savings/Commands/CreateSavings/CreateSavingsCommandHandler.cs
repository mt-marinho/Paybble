using AutoMapper;
using MediatR;
using Paybble.Application.Contracts.Persistence;
using Paybble.Domain.Entities;

namespace Paybble.Application.Features.Savings.Commands.CreateSavings
{
    public class CreateSavingsCommandHandler(ISavingsRepository savingsRepository, IMapper mapper) : IRequestHandler<CreateSavingsCommand, CreateSavingsResponse>
    {
        public async Task<CreateSavingsResponse> Handle(CreateSavingsCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateSavingsResponse();

            var savings = new Saving(
                description: request.description,
                goalValue: request.goalValue
            );

            var createdSaving = await savingsRepository.AddAsync(savings);

            response.savings = mapper.Map<CreateSavingsDTO>(createdSaving);
            response.savings.Progress = 0;

            return response;
        }
    }
}
