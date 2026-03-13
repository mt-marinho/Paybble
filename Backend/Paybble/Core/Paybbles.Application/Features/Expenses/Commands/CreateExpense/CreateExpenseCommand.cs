using MediatR;
using Paybble.Domain.Enums;

namespace Paybble.Application.Features.Expenses.Commands.CreateExpense
{
    public record CreateExpenseCommand
    (
        string Description,
        int Value,
        int Year,
        int Month,
        Recurrence Recurrence,
        int Frequency,
        DateOnly DueDate
    ) : IRequest<CreateExpenseResponse>;
}
