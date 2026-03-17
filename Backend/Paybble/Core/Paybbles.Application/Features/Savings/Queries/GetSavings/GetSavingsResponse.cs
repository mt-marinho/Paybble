using Paybble.Application.Responses;

namespace Paybble.Application.Features.Savings.Queries.GetSavings
{
    public class GetSavingsResponse : BaseResponse
    {
        public GetSavingsResponse() : base()
        { 
        }

        public GetSavingsDTO savings { get; set; }
    }
}
