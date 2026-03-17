using MediatR;

namespace Paybble.Application.Features.Savings.Commands.DeleteSavings
{
    public record DeleteSavingsCommand(int id) : IRequest;
}
