using Paybble.Domain.Enums;

namespace Paybble.Application.Features.CreditCardPurchases.Queries.GetCreditCardPurchaseList
{
    public class CreditCardPurchaseListDTO
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal TotalValue { get; set; }
        public int InstallmentsCount { get; set; }
        public DateOnly PurchaseDate { get; set; }
    }
}
