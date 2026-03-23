using Paybble.Domain.Enums;

namespace Paybble.Application.Features.CreditCardPurchases.Commands.CreateCreditCardPurchase
{
    public class CreateCreditCardPurchaseDTO
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal TotalValue { get; set; }
        public int InstallmentsCount { get; set; }
        public DateOnly PurchaseDate { get; set; }
        public DateOnly FirstInstallmentDate { get; set; }
    }
}
