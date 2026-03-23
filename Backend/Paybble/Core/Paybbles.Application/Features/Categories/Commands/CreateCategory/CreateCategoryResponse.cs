using Paybble.Application.Responses;

namespace Paybble.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryResponse : BaseResponse
    {
        public CreateCategoryResponse() : base()
        {
        }

        public CreateCategoryDTO Category { get; set; }
    }
}
