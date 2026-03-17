using Paybble.Application.Responses;

namespace Paybble.Application.Features.Transfers.Queries.GetTransfer
{
    public class GetTransferResponse : BaseResponse
    {
        public GetTransferResponse() : base()
        { 
        }

        public GetTransferDTO trnasfer { get; set; }
    }
}
