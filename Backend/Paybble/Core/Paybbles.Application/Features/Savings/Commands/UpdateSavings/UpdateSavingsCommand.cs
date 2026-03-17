using MediatR;

namespace Paybble.Application.Features.Savings.Commands.UpdateSavings
{
    public record UpdateSavingsCommand(
        int id, 
        string description, 
        int goalValue
    ) : IRequest;
}
