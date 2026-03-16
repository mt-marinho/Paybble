using Paybble.Domain.Entities;

namespace Paybble.Application.Contracts.Persistence
{
    public interface ISavingsRepository : IAsyncRepository<Saving>
    {
    }
}
