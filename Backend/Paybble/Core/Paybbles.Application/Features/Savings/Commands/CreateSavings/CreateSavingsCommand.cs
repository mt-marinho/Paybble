using MediatR;

namespace Paybble.Application.Features.Savings.Commands.CreateSavings
{
    public record CreateSavingsCommand(
        string description,
        decimal goalValue
    ) : IRequest<CreateSavingsResponse>;
}
