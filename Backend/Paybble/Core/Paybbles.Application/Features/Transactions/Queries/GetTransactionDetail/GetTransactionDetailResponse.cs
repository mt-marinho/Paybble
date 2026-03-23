using Paybble.Application.Responses;

namespace Paybble.Application.Features.Transactions.Queries.GetTransactionDetail
{
    public class GetTransactionDetailResponse : BaseResponse
    {
        public GetTransactionDetailResponse() : base()
        {
        }

        public TransactionDetailVm Transaction { get; set; }
    }
}
