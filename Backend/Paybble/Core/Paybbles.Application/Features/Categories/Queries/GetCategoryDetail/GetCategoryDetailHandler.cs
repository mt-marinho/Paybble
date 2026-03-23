using AutoMapper;
using MediatR;
using Paybble.Application.Contracts.Persistence;
using Paybble.Application.Exceptions;
using Paybble.Domain.Entities;

namespace Paybble.Application.Features.Categories.Queries.GetCategoryDetail
{
    public class GetCategoryDetailHandler(ICategoryRepository categoryRepository, IMapper mapper) 
        : IRequestHandler<GetCategoryDetailQuery, GetCategoryDetailResponse>
    {
        public async Task<GetCategoryDetailResponse> Handle(GetCategoryDetailQuery request, CancellationToken cancellationToken)
        {
            var response = new GetCategoryDetailResponse();

            var category = await categoryRepository.GetByIdAsync(request.Id);

            if (category == null)
                throw new NotFoundException(nameof(Category), request.Id);

            response.Category = mapper.Map<CategoryDetailVm>(category);
            return response;
        }
    }
}
