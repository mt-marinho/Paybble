using Paybble.Application.Responses;

namespace Paybble.Application.Features.Expenses.Commands.CreateExpense
{
    public class CreateExpenseResponse : BaseResponse
    {
        public CreateExpenseResponse() : base()
        {
        }

        public CreateExpenseDTO Expense { get; set; }
    }
}
