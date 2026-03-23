using MediatR;

namespace Paybble.Application.Features.CreditCardPurchases.Commands.UpdateCreditCardPurchase
{
    public class UpdateCreditCardPurchaseCommand : IRequest
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal TotalValue { get; set; }
        public int InstallmentsCount { get; set; }
        public DateOnly PurchaseDate { get; set; }
        public DateOnly FirstInstallmentDate { get; set; }
    }
}
