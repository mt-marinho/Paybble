using Paybble.Application.Responses;

namespace Paybble.Application.Features.Incomes.Queries.GetIncomeDetail
{
    public class GetIncomeDetailResponse : BaseResponse
    {
        public GetIncomeDetailResponse() : base() 
        { 
        }

        public IncomeDetailVm income { get; set; }
    }
}
