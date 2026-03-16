using Paybble.Application.Responses;

namespace Paybble.Application.Features.Savings.Commands.CreateSavings
{
    public class CreateSavingsResponse : BaseResponse
    {
        public CreateSavingsResponse() : base()
        { 
        }

        public CreateSavingsDTO savings { get; set; }
    }
}
