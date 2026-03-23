using Paybble.Application.Features.Transactions.Queries.GetTransactionDetail;
using Paybble.Domain.Enums;

namespace Paybble.Application.Features.CreditCardPurchases.Queries.GetCreditCardPurchaseDetail
{
    public class CreditCardPurchaseDetailDTO
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal TotalValue { get; set; }
        public int InstallmentsCount { get; set; }
        public DateOnly PurchaseDate { get; set; }
        public DateOnly FirstInstallmentDate { get; set; }
        public ICollection<TransactionDetailVm> Transactions { get; set; }
    }
}
