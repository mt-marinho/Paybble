using Paybble.Application.Responses;

namespace Paybble.Application.Features.Categories.Queries.GetCategoryDetail
{
    public class GetCategoryDetailResponse : BaseResponse
    {
        public GetCategoryDetailResponse() : base()
        {
        }

        public CategoryDetailVm Category { get; set; }
    }
}
