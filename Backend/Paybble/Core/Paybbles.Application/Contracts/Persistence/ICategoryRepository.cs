using Paybble.Domain.Entities;

namespace Paybble.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<IReadOnlyList<Category>> GetCategoriesByNameAsync(string name);
    }
}
