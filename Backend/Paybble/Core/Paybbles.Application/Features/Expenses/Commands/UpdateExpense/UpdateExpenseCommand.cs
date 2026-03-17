using MediatR;
using Paybble.Domain.Enums;

namespace Paybble.Application.Features.Expenses.Commands.UpdateExpense
{
    public record UpdateExpenseCommand(
        int id, 
        string description, 
        decimal value, 
        DateOnly DueDate, 
        Recurrence recurrence, 
        int frequency
    ) : IRequest;
}
