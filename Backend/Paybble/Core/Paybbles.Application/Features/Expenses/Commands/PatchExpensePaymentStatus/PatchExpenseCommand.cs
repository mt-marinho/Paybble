using MediatR;

namespace Paybble.Application.Features.Expenses.Commands.PatchExpensePaymentStatus
{
    public record PatchExpenseCommand(int id) : IRequest;
}
