using Paybble.Application.Responses;

namespace Paybble.Application.Features.Savings.Queries.GetSavingsList
{
    public class GetSavingsListResponse : BaseResponse
    {
        public GetSavingsListResponse() : base()
        {
        }

        public List<GetSavingsListDTO> savings { get; set; }
    }
}
