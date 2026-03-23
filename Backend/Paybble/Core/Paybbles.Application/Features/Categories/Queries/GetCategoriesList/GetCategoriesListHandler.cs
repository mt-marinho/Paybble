using AutoMapper;
using MediatR;
using Paybble.Application.Contracts.Persistence;

namespace Paybble.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListHandler(ICategoryRepository categoryRepository, IMapper mapper) 
        : IRequestHandler<GetCategoriesListQuery, GetCategoriesListResponse>
    {
        public async Task<GetCategoriesListResponse> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var response = new GetCategoriesListResponse();

            var categories = await categoryRepository.ListAllAsync();
            response.Categories = mapper.Map<List<CategoryListVm>>(categories);

            return response;
        }
    }
}
