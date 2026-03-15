using MediatR;

namespace Paybble.Application.Features.Incomes.Commands.DeleteIncome
{
    public record DeleteIncomeCommand(int id) : IRequest;
}
