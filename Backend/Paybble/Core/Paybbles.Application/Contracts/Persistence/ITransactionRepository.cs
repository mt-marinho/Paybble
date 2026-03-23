using Paybble.Domain.Entities;

namespace Paybble.Application.Contracts.Persistence
{
    public interface ITransactionRepository : IAsyncRepository<Transaction>
    {
        Task<IReadOnlyList<Transaction>> GetTransactionsByYearMonthAsync(int year, int? month);
    }
}
