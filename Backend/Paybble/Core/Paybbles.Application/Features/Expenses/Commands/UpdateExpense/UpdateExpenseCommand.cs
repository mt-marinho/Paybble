using MediatR;
using Paybble.Domain.Enums;

namespace Paybble.Application.Features.Expenses.Commands.UpdateExpense
{
    public record UpdateExpenseCommand(int id, string description, int value, DateOnly DueDate, Recurrence recurrence, int frequency) : IRequest;
}
