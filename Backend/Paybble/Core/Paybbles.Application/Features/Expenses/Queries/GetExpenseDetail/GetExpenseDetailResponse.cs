using Paybble.Application.Features.Expenses.Queries.GetExpense;
using Paybble.Application.Responses;

namespace Paybble.Application.Features.Expenses.Queries.GetExpenseDetail
{
    public class GetExpenseDetailResponse : BaseResponse
    {
        public GetExpenseDetailResponse() : base()
        {
        }

        public ExpenseDetailVm expense { get; set; }
    }
}
