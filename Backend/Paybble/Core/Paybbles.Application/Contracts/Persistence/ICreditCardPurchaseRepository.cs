using Paybble.Domain.Entities;

namespace Paybble.Application.Contracts.Persistence
{
    public interface ICreditCardPurchaseRepository : IAsyncRepository<CreditCardPurchase>
    {
        Task<CreditCardPurchase?> GetCreditCardPurchaseWithDetailsAsync(int id);
    }
}
