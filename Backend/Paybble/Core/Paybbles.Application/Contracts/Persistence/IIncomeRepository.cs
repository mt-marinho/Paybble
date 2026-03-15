using Paybble.Domain.Entities;

namespace Paybble.Application.Contracts.Persistence
{
    public interface IIncomeRepository : IAsyncRepository<Income>
    {
        Task<IReadOnlyList<Income>> GetIncomesByYearMonthAsync(int year, int? month);
    }
}
