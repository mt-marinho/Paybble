using Paybble.Application.Responses;

namespace Paybble.Application.Features.Expenses.Queries.GetExpensesByYearMonth
{
    public class ExpensesByYearMonthResponse : BaseResponse
    {
        public ExpensesByYearMonthResponse() : base()
        { 
        }

        public List<ExpensesByYearMonthVm> expenses { get; set; }
    }
}
