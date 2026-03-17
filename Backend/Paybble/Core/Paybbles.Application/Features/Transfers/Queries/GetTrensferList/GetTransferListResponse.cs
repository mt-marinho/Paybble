using Paybble.Application.Responses;

namespace Paybble.Application.Features.Transfers.Queries.GetTrensferList
{
    public class GetTransferListResponse : BaseResponse
    {
        public GetTransferListResponse() : base()
        { 
        }

        public List<GetTransferListDTO> transfers { get; set; }
    }
}
