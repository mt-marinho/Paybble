using MediatR;
using Paybble.Application.Features.Incomes.Commands.CreateIncome;
using Paybble.Domain.Enums;

namespace Paybble.Application.Features.Incomes.Commands.CreateIncome
{
    public record CreateIncomeCommand(
        string Description,
        int Value,
        int Year,
        int Month,
        Recurrence Recurrence,
        int Frequency,
        DateOnly? PaymentDate ) : IRequest<CreateIncomeReponse>;
}
