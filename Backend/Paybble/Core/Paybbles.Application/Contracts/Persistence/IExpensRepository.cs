using Paybble.Domain.Entities;

namespace Paybble.Application.Contracts.Persistence
{
    public interface IExpensRepository : IAsyncRepository<Expense>
    {
        Task<IReadOnlyList<Expense>> GetExpensesByYearMonthAsync(int year, int? month);
    }
}
