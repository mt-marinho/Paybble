using Paybble.Application.Responses;

namespace Paybble.Application.Features.Transactions.Commands.CreateTransaction
{
    public class CreateTransactionResponse : BaseResponse
    {
        public CreateTransactionResponse() : base()
        {
        }

        public CreateTransactionDTO Transaction { get; set; }
    }
}
