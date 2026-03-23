using Paybble.Application.Responses;

namespace Paybble.Application.Features.Transactions.Queries.GetTransactionsByYearMonth
{
    public class TransactionsByYearMonthResponse : BaseResponse
    {
        public TransactionsByYearMonthResponse() : base()
        {
        }

        public List<TransactionsByYearMonthVm> Transactions { get; set; }
    }
}
