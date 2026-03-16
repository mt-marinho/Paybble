using MediatR;

namespace Paybble.Application.Features.Savings.Commands.CreateSavings
{
    public record CreateSavingsCommand(string description, int goalValue) : IRequest<CreateSavingsResponse>;
}
