using Paybble.Application.Responses;

namespace Paybble.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListResponse : BaseResponse
    {
        public GetCategoriesListResponse() : base()
        {
        }

        public List<CategoryListVm> Categories { get; set; }
    }
}
