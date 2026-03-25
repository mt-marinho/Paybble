using AutoMapper;
using MediatR;
using Paybble.Application.Contracts.Persistence;
using Paybble.Domain.Entities;

namespace Paybble.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<CreateCategoryCommand, CreateCategoryResponse>
    {
        public async Task<CreateCategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateCategoryResponse();

            var category = new Category(
                request.Name
            );

            var createdCategory = await categoryRepository.AddAsync(category);
            response.Category = mapper.Map<CreateCategoryDTO>(createdCategory);
            return response;
        }
    }
}
