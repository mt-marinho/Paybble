using MediatR;
using Paybble.Domain.Enums;

namespace Paybble.Application.Features.Incomes.Commands.UpdateIncome
{
    public record UpdateIncomeCommand(
        int id, 
        string description,
        decimal value, 
        Recurrence recurrence, 
        int frequency, 
        DateOnly? PaymentDate
    ) : IRequest;
}
